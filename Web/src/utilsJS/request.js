import axios from 'axios'
import {Local} from "/@/utils/storage";
import {
    accessTokenKey,
    clearAccessTokens,
    decryptJWT,
    getJWTDate,
    refreshAccessTokenKey,
    tansParams
} from "/@/utils/request";
import {number} from "echarts";
// import router from '@/router'

const baseURL = 'http://localhost:5005'
export const getToken = () => {
    return Local.get(accessTokenKey);
};

const instance = axios.create({
    // TODO 1. 基础地址，超时时间
    baseURL: baseURL,
    timeout: 10000
})

// 添加请求拦截器
instance.interceptors.request.use(
    (config) => {
        // 在发送请求之前做些什么 token
        // if (Session.get('token')) {
        //   (<any>config.headers).common['Authorization'] = `${Session.get('token')}`;
        // }

        // 获取本地的 token
        const accessToken = localStorage.getItem(accessTokenKey);
        if (accessToken) {
            // 将 token 添加到请求报文头中
            config.headers['Authorization'] = `Bearer ${accessToken}`;

            // // 判断 accessToken 是否过期
            // const jwt = decryptJWT(accessToken);
            // const exp = getJWTDate(jwt.exp as number);
            //
            // // token 已经过期
            // if (new Date() >= exp) {
            //     // 获取刷新 token
            //     const refreshAccessToken = localStorage.getItem(refreshAccessTokenKey);
            //
            //     // 携带刷新 token
            //     if (refreshAccessToken) {
            //         config.headers['X-Authorization'] = `Bearer ${refreshAccessToken}`;
            //     }
            // }

            // get请求映射params参数
            if (config.method.toLowerCase() === 'get' && config.data) {
                let url = config.url + '?' + tansParams(config.data);
                url = url.slice(0, -1);
                config.data = {};
                config.url = url;
            }
        }
        return config;
    },
    (error) => {
        // 对请求错误做些什么
        return Promise.reject(error);
    }
);

// 添加响应拦截器
instance.interceptors.response.use(
    (res) => {
        // 获取状态码和返回数据
        const status = res.status;
        const serve = res.data;

        // 处理 401
        if (status === 401) {
            clearAccessTokens();
        }

        // 处理未进行规范化处理的
        if (status >= 400) {
            throw new Error(res.statusText || 'Request Error.');
        }

        // 处理规范化结果错误
        if (serve && serve.hasOwnProperty('errors') && serve.errors) {
            throw new Error(JSON.stringify(serve.errors || 'Request Error.'));
        }

        // 读取响应报文头 token 信息
        const accessToken = res.headers[accessTokenKey];
        const refreshAccessToken = res.headers[refreshAccessTokenKey];

        // 判断是否是无效 token
        if (accessToken === 'invalid_token') {
            clearAccessTokens();
        }
        // 判断是否存在刷新 token，如果存在则存储在本地
        else if (refreshAccessToken && accessToken && accessToken !== 'invalid_token') {
            Local.set(accessTokenKey, accessToken);
            Local.set(refreshAccessTokenKey, refreshAccessToken);
        }

        // 响应拦截及自定义处理
        if (serve.code === 401) {
            clearAccessTokens();
        } else if (serve.code === undefined) {
            return Promise.resolve(res);
        } else if (serve.code !== 200) {
            let message;
            // 判断 serve.message 是否为对象
            if (serve.message && typeof serve.message === 'object') {
                message = JSON.stringify(serve.message);
            } else {
                message = serve.message;
            }
       //     ElMessage.error(message);
            throw new Error(message);
        }

        return res;
    },
    (error) => {
        // 处理响应错误
        if (error.response) {
            if (error.response.status === 401) {
                clearAccessTokens();
            }
        }

        // // 对响应错误做点什么
        // if (error.message.indexOf('timeout') !== -1) {
        //     ElMessage.error('网络超时');
        // } else if (error.message === 'Network Error') {
        //     ElMessage.error('网络连接错误');
        // } else {
        //     if (error.response.data) ElMessage.error(error.response.statusText);
        //     else ElMessage.error('接口路径找不到');
        // }

        return Promise.reject(error);
    }
);

export default instance
export { baseURL }
