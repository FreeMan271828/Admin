/* tslint:disable */
/* eslint-disable */
/**
 * Admin.NET 通用权限开发平台
 * 让 .NET 开发更简单、更通用、更流行。前后端分离架构(.NET6/Vue3)，开箱即用紧随前沿技术。<br/><a href='https://gitee.com/zuohuaijun/Admin.NET/'>https://gitee.com/zuohuaijun/Admin.NET</a>
 *
 * OpenAPI spec version: 1.0.0
 * 
 *
 * NOTE: This class is auto generated by the swagger code generator program.
 * https://github.com/swagger-api/swagger-codegen.git
 * Do not edit the class manually.
 */

import globalAxios, { AxiosResponse, AxiosInstance, AxiosRequestConfig } from 'axios';
import { Configuration } from '../configuration';
// Some imports not used depending on template conditions
// @ts-ignore
import { BASE_PATH, COLLECTION_FORMATS, RequestArgs, BaseAPI, RequiredError } from '../base';
import { AdminResultJObject } from '../models';
import { JToken } from '../models';
/**
 * APIJSONApi - axios parameter creator
 * @export
 */
export const APIJSONApiAxiosParamCreator = function (configuration?: Configuration) {
    return {
        /**
         * 
         * @summary 新增
         * @param {{ [key: string]: JToken; }} [body] 表对象或数组，若没有传Id则后端生成Id
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        apiAPIJSONAddPost: async (body?: { [key: string]: JToken; }, options: AxiosRequestConfig = {}): Promise<RequestArgs> => {
            const localVarPath = `/api/aPIJSON/add`;
            // use dummy base URL string because the URL constructor only accepts absolute URLs.
            const localVarUrlObj = new URL(localVarPath, 'https://example.com');
            let baseOptions;
            if (configuration) {
                baseOptions = configuration.baseOptions;
            }
            const localVarRequestOptions :AxiosRequestConfig = { method: 'POST', ...baseOptions, ...options};
            const localVarHeaderParameter = {} as any;
            const localVarQueryParameter = {} as any;

            // authentication Bearer required
            // http bearer authentication required
            if (configuration && configuration.accessToken) {
                const accessToken = typeof configuration.accessToken === 'function'
                    ? await configuration.accessToken()
                    : await configuration.accessToken;
                localVarHeaderParameter["Authorization"] = "Bearer " + accessToken;
            }

            localVarHeaderParameter['Content-Type'] = 'application/json-patch+json';

            const query = new URLSearchParams(localVarUrlObj.search);
            for (const key in localVarQueryParameter) {
                query.set(key, localVarQueryParameter[key]);
            }
            for (const key in options.params) {
                query.set(key, options.params[key]);
            }
            localVarUrlObj.search = (new URLSearchParams(query)).toString();
            let headersFromBaseOptions = baseOptions && baseOptions.headers ? baseOptions.headers : {};
            localVarRequestOptions.headers = {...localVarHeaderParameter, ...headersFromBaseOptions, ...options.headers};
            const needsSerialization = (typeof body !== "string") || localVarRequestOptions.headers['Content-Type'] === 'application/json';
            localVarRequestOptions.data =  needsSerialization ? JSON.stringify(body !== undefined ? body : {}) : (body || "");

            return {
                url: localVarUrlObj.pathname + localVarUrlObj.search + localVarUrlObj.hash,
                options: localVarRequestOptions,
            };
        },
        /**
         * 
         * @summary 删除（支持非Id条件、支持批量）
         * @param {{ [key: string]: JToken; }} [body] 
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        apiAPIJSONDeletePost: async (body?: { [key: string]: JToken; }, options: AxiosRequestConfig = {}): Promise<RequestArgs> => {
            const localVarPath = `/api/aPIJSON/delete`;
            // use dummy base URL string because the URL constructor only accepts absolute URLs.
            const localVarUrlObj = new URL(localVarPath, 'https://example.com');
            let baseOptions;
            if (configuration) {
                baseOptions = configuration.baseOptions;
            }
            const localVarRequestOptions :AxiosRequestConfig = { method: 'POST', ...baseOptions, ...options};
            const localVarHeaderParameter = {} as any;
            const localVarQueryParameter = {} as any;

            // authentication Bearer required
            // http bearer authentication required
            if (configuration && configuration.accessToken) {
                const accessToken = typeof configuration.accessToken === 'function'
                    ? await configuration.accessToken()
                    : await configuration.accessToken;
                localVarHeaderParameter["Authorization"] = "Bearer " + accessToken;
            }

            localVarHeaderParameter['Content-Type'] = 'application/json-patch+json';

            const query = new URLSearchParams(localVarUrlObj.search);
            for (const key in localVarQueryParameter) {
                query.set(key, localVarQueryParameter[key]);
            }
            for (const key in options.params) {
                query.set(key, options.params[key]);
            }
            localVarUrlObj.search = (new URLSearchParams(query)).toString();
            let headersFromBaseOptions = baseOptions && baseOptions.headers ? baseOptions.headers : {};
            localVarRequestOptions.headers = {...localVarHeaderParameter, ...headersFromBaseOptions, ...options.headers};
            const needsSerialization = (typeof body !== "string") || localVarRequestOptions.headers['Content-Type'] === 'application/json';
            localVarRequestOptions.data =  needsSerialization ? JSON.stringify(body !== undefined ? body : {}) : (body || "");

            return {
                url: localVarUrlObj.pathname + localVarUrlObj.search + localVarUrlObj.hash,
                options: localVarRequestOptions,
            };
        },
        /**
         * 参数：{\"[]\":{\"SYSLOGOP\":{}}}
         * @summary 统一查询入口
         * @param {{ [key: string]: JToken; }} [body] 
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        apiAPIJSONGetPost: async (body?: { [key: string]: JToken; }, options: AxiosRequestConfig = {}): Promise<RequestArgs> => {
            const localVarPath = `/api/aPIJSON/get`;
            // use dummy base URL string because the URL constructor only accepts absolute URLs.
            const localVarUrlObj = new URL(localVarPath, 'https://example.com');
            let baseOptions;
            if (configuration) {
                baseOptions = configuration.baseOptions;
            }
            const localVarRequestOptions :AxiosRequestConfig = { method: 'POST', ...baseOptions, ...options};
            const localVarHeaderParameter = {} as any;
            const localVarQueryParameter = {} as any;

            // authentication Bearer required
            // http bearer authentication required
            if (configuration && configuration.accessToken) {
                const accessToken = typeof configuration.accessToken === 'function'
                    ? await configuration.accessToken()
                    : await configuration.accessToken;
                localVarHeaderParameter["Authorization"] = "Bearer " + accessToken;
            }

            localVarHeaderParameter['Content-Type'] = 'application/json-patch+json';

            const query = new URLSearchParams(localVarUrlObj.search);
            for (const key in localVarQueryParameter) {
                query.set(key, localVarQueryParameter[key]);
            }
            for (const key in options.params) {
                query.set(key, options.params[key]);
            }
            localVarUrlObj.search = (new URLSearchParams(query)).toString();
            let headersFromBaseOptions = baseOptions && baseOptions.headers ? baseOptions.headers : {};
            localVarRequestOptions.headers = {...localVarHeaderParameter, ...headersFromBaseOptions, ...options.headers};
            const needsSerialization = (typeof body !== "string") || localVarRequestOptions.headers['Content-Type'] === 'application/json';
            localVarRequestOptions.data =  needsSerialization ? JSON.stringify(body !== undefined ? body : {}) : (body || "");

            return {
                url: localVarUrlObj.pathname + localVarUrlObj.search + localVarUrlObj.hash,
                options: localVarRequestOptions,
            };
        },
        /**
         * 
         * @summary 查询表
         * @param {string} table 
         * @param {{ [key: string]: JToken; }} [body] 
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        apiAPIJSONGetTablePost: async (table: string, body?: { [key: string]: JToken; }, options: AxiosRequestConfig = {}): Promise<RequestArgs> => {
            // verify required parameter 'table' is not null or undefined
            if (table === null || table === undefined) {
                throw new RequiredError('table','Required parameter table was null or undefined when calling apiAPIJSONGetTablePost.');
            }
            const localVarPath = `/api/aPIJSON/get/{table}`
                .replace(`{${"table"}}`, encodeURIComponent(String(table)));
            // use dummy base URL string because the URL constructor only accepts absolute URLs.
            const localVarUrlObj = new URL(localVarPath, 'https://example.com');
            let baseOptions;
            if (configuration) {
                baseOptions = configuration.baseOptions;
            }
            const localVarRequestOptions :AxiosRequestConfig = { method: 'POST', ...baseOptions, ...options};
            const localVarHeaderParameter = {} as any;
            const localVarQueryParameter = {} as any;

            // authentication Bearer required
            // http bearer authentication required
            if (configuration && configuration.accessToken) {
                const accessToken = typeof configuration.accessToken === 'function'
                    ? await configuration.accessToken()
                    : await configuration.accessToken;
                localVarHeaderParameter["Authorization"] = "Bearer " + accessToken;
            }

            localVarHeaderParameter['Content-Type'] = 'application/json-patch+json';

            const query = new URLSearchParams(localVarUrlObj.search);
            for (const key in localVarQueryParameter) {
                query.set(key, localVarQueryParameter[key]);
            }
            for (const key in options.params) {
                query.set(key, options.params[key]);
            }
            localVarUrlObj.search = (new URLSearchParams(query)).toString();
            let headersFromBaseOptions = baseOptions && baseOptions.headers ? baseOptions.headers : {};
            localVarRequestOptions.headers = {...localVarHeaderParameter, ...headersFromBaseOptions, ...options.headers};
            const needsSerialization = (typeof body !== "string") || localVarRequestOptions.headers['Content-Type'] === 'application/json';
            localVarRequestOptions.data =  needsSerialization ? JSON.stringify(body !== undefined ? body : {}) : (body || "");

            return {
                url: localVarUrlObj.pathname + localVarUrlObj.search + localVarUrlObj.hash,
                options: localVarRequestOptions,
            };
        },
        /**
         * 
         * @summary 修改（只支持Id作为条件）
         * @param {{ [key: string]: JToken; }} [body] 支持多表、多Id批量更新
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        apiAPIJSONUpdatePost: async (body?: { [key: string]: JToken; }, options: AxiosRequestConfig = {}): Promise<RequestArgs> => {
            const localVarPath = `/api/aPIJSON/update`;
            // use dummy base URL string because the URL constructor only accepts absolute URLs.
            const localVarUrlObj = new URL(localVarPath, 'https://example.com');
            let baseOptions;
            if (configuration) {
                baseOptions = configuration.baseOptions;
            }
            const localVarRequestOptions :AxiosRequestConfig = { method: 'POST', ...baseOptions, ...options};
            const localVarHeaderParameter = {} as any;
            const localVarQueryParameter = {} as any;

            // authentication Bearer required
            // http bearer authentication required
            if (configuration && configuration.accessToken) {
                const accessToken = typeof configuration.accessToken === 'function'
                    ? await configuration.accessToken()
                    : await configuration.accessToken;
                localVarHeaderParameter["Authorization"] = "Bearer " + accessToken;
            }

            localVarHeaderParameter['Content-Type'] = 'application/json-patch+json';

            const query = new URLSearchParams(localVarUrlObj.search);
            for (const key in localVarQueryParameter) {
                query.set(key, localVarQueryParameter[key]);
            }
            for (const key in options.params) {
                query.set(key, options.params[key]);
            }
            localVarUrlObj.search = (new URLSearchParams(query)).toString();
            let headersFromBaseOptions = baseOptions && baseOptions.headers ? baseOptions.headers : {};
            localVarRequestOptions.headers = {...localVarHeaderParameter, ...headersFromBaseOptions, ...options.headers};
            const needsSerialization = (typeof body !== "string") || localVarRequestOptions.headers['Content-Type'] === 'application/json';
            localVarRequestOptions.data =  needsSerialization ? JSON.stringify(body !== undefined ? body : {}) : (body || "");

            return {
                url: localVarUrlObj.pathname + localVarUrlObj.search + localVarUrlObj.hash,
                options: localVarRequestOptions,
            };
        },
    }
};

/**
 * APIJSONApi - functional programming interface
 * @export
 */
export const APIJSONApiFp = function(configuration?: Configuration) {
    return {
        /**
         * 
         * @summary 新增
         * @param {{ [key: string]: JToken; }} [body] 表对象或数组，若没有传Id则后端生成Id
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        async apiAPIJSONAddPost(body?: { [key: string]: JToken; }, options?: AxiosRequestConfig): Promise<(axios?: AxiosInstance, basePath?: string) => Promise<AxiosResponse<AdminResultJObject>>> {
            const localVarAxiosArgs = await APIJSONApiAxiosParamCreator(configuration).apiAPIJSONAddPost(body, options);
            return (axios: AxiosInstance = globalAxios, basePath: string = BASE_PATH) => {
                const axiosRequestArgs :AxiosRequestConfig = {...localVarAxiosArgs.options, url: basePath + localVarAxiosArgs.url};
                return axios.request(axiosRequestArgs);
            };
        },
        /**
         * 
         * @summary 删除（支持非Id条件、支持批量）
         * @param {{ [key: string]: JToken; }} [body] 
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        async apiAPIJSONDeletePost(body?: { [key: string]: JToken; }, options?: AxiosRequestConfig): Promise<(axios?: AxiosInstance, basePath?: string) => Promise<AxiosResponse<AdminResultJObject>>> {
            const localVarAxiosArgs = await APIJSONApiAxiosParamCreator(configuration).apiAPIJSONDeletePost(body, options);
            return (axios: AxiosInstance = globalAxios, basePath: string = BASE_PATH) => {
                const axiosRequestArgs :AxiosRequestConfig = {...localVarAxiosArgs.options, url: basePath + localVarAxiosArgs.url};
                return axios.request(axiosRequestArgs);
            };
        },
        /**
         * 参数：{\"[]\":{\"SYSLOGOP\":{}}}
         * @summary 统一查询入口
         * @param {{ [key: string]: JToken; }} [body] 
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        async apiAPIJSONGetPost(body?: { [key: string]: JToken; }, options?: AxiosRequestConfig): Promise<(axios?: AxiosInstance, basePath?: string) => Promise<AxiosResponse<AdminResultJObject>>> {
            const localVarAxiosArgs = await APIJSONApiAxiosParamCreator(configuration).apiAPIJSONGetPost(body, options);
            return (axios: AxiosInstance = globalAxios, basePath: string = BASE_PATH) => {
                const axiosRequestArgs :AxiosRequestConfig = {...localVarAxiosArgs.options, url: basePath + localVarAxiosArgs.url};
                return axios.request(axiosRequestArgs);
            };
        },
        /**
         * 
         * @summary 查询表
         * @param {string} table 
         * @param {{ [key: string]: JToken; }} [body] 
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        async apiAPIJSONGetTablePost(table: string, body?: { [key: string]: JToken; }, options?: AxiosRequestConfig): Promise<(axios?: AxiosInstance, basePath?: string) => Promise<AxiosResponse<AdminResultJObject>>> {
            const localVarAxiosArgs = await APIJSONApiAxiosParamCreator(configuration).apiAPIJSONGetTablePost(table, body, options);
            return (axios: AxiosInstance = globalAxios, basePath: string = BASE_PATH) => {
                const axiosRequestArgs :AxiosRequestConfig = {...localVarAxiosArgs.options, url: basePath + localVarAxiosArgs.url};
                return axios.request(axiosRequestArgs);
            };
        },
        /**
         * 
         * @summary 修改（只支持Id作为条件）
         * @param {{ [key: string]: JToken; }} [body] 支持多表、多Id批量更新
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        async apiAPIJSONUpdatePost(body?: { [key: string]: JToken; }, options?: AxiosRequestConfig): Promise<(axios?: AxiosInstance, basePath?: string) => Promise<AxiosResponse<AdminResultJObject>>> {
            const localVarAxiosArgs = await APIJSONApiAxiosParamCreator(configuration).apiAPIJSONUpdatePost(body, options);
            return (axios: AxiosInstance = globalAxios, basePath: string = BASE_PATH) => {
                const axiosRequestArgs :AxiosRequestConfig = {...localVarAxiosArgs.options, url: basePath + localVarAxiosArgs.url};
                return axios.request(axiosRequestArgs);
            };
        },
    }
};

/**
 * APIJSONApi - factory interface
 * @export
 */
export const APIJSONApiFactory = function (configuration?: Configuration, basePath?: string, axios?: AxiosInstance) {
    return {
        /**
         * 
         * @summary 新增
         * @param {{ [key: string]: JToken; }} [body] 表对象或数组，若没有传Id则后端生成Id
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        async apiAPIJSONAddPost(body?: { [key: string]: JToken; }, options?: AxiosRequestConfig): Promise<AxiosResponse<AdminResultJObject>> {
            return APIJSONApiFp(configuration).apiAPIJSONAddPost(body, options).then((request) => request(axios, basePath));
        },
        /**
         * 
         * @summary 删除（支持非Id条件、支持批量）
         * @param {{ [key: string]: JToken; }} [body] 
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        async apiAPIJSONDeletePost(body?: { [key: string]: JToken; }, options?: AxiosRequestConfig): Promise<AxiosResponse<AdminResultJObject>> {
            return APIJSONApiFp(configuration).apiAPIJSONDeletePost(body, options).then((request) => request(axios, basePath));
        },
        /**
         * 参数：{\"[]\":{\"SYSLOGOP\":{}}}
         * @summary 统一查询入口
         * @param {{ [key: string]: JToken; }} [body] 
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        async apiAPIJSONGetPost(body?: { [key: string]: JToken; }, options?: AxiosRequestConfig): Promise<AxiosResponse<AdminResultJObject>> {
            return APIJSONApiFp(configuration).apiAPIJSONGetPost(body, options).then((request) => request(axios, basePath));
        },
        /**
         * 
         * @summary 查询表
         * @param {string} table 
         * @param {{ [key: string]: JToken; }} [body] 
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        async apiAPIJSONGetTablePost(table: string, body?: { [key: string]: JToken; }, options?: AxiosRequestConfig): Promise<AxiosResponse<AdminResultJObject>> {
            return APIJSONApiFp(configuration).apiAPIJSONGetTablePost(table, body, options).then((request) => request(axios, basePath));
        },
        /**
         * 
         * @summary 修改（只支持Id作为条件）
         * @param {{ [key: string]: JToken; }} [body] 支持多表、多Id批量更新
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        async apiAPIJSONUpdatePost(body?: { [key: string]: JToken; }, options?: AxiosRequestConfig): Promise<AxiosResponse<AdminResultJObject>> {
            return APIJSONApiFp(configuration).apiAPIJSONUpdatePost(body, options).then((request) => request(axios, basePath));
        },
    };
};

/**
 * APIJSONApi - object-oriented interface
 * @export
 * @class APIJSONApi
 * @extends {BaseAPI}
 */
export class APIJSONApi extends BaseAPI {
    /**
     * 
     * @summary 新增
     * @param {{ [key: string]: JToken; }} [body] 表对象或数组，若没有传Id则后端生成Id
     * @param {*} [options] Override http request option.
     * @throws {RequiredError}
     * @memberof APIJSONApi
     */
    public async apiAPIJSONAddPost(body?: { [key: string]: JToken; }, options?: AxiosRequestConfig) : Promise<AxiosResponse<AdminResultJObject>> {
        return APIJSONApiFp(this.configuration).apiAPIJSONAddPost(body, options).then((request) => request(this.axios, this.basePath));
    }
    /**
     * 
     * @summary 删除（支持非Id条件、支持批量）
     * @param {{ [key: string]: JToken; }} [body] 
     * @param {*} [options] Override http request option.
     * @throws {RequiredError}
     * @memberof APIJSONApi
     */
    public async apiAPIJSONDeletePost(body?: { [key: string]: JToken; }, options?: AxiosRequestConfig) : Promise<AxiosResponse<AdminResultJObject>> {
        return APIJSONApiFp(this.configuration).apiAPIJSONDeletePost(body, options).then((request) => request(this.axios, this.basePath));
    }
    /**
     * 参数：{\"[]\":{\"SYSLOGOP\":{}}}
     * @summary 统一查询入口
     * @param {{ [key: string]: JToken; }} [body] 
     * @param {*} [options] Override http request option.
     * @throws {RequiredError}
     * @memberof APIJSONApi
     */
    public async apiAPIJSONGetPost(body?: { [key: string]: JToken; }, options?: AxiosRequestConfig) : Promise<AxiosResponse<AdminResultJObject>> {
        return APIJSONApiFp(this.configuration).apiAPIJSONGetPost(body, options).then((request) => request(this.axios, this.basePath));
    }
    /**
     * 
     * @summary 查询表
     * @param {string} table 
     * @param {{ [key: string]: JToken; }} [body] 
     * @param {*} [options] Override http request option.
     * @throws {RequiredError}
     * @memberof APIJSONApi
     */
    public async apiAPIJSONGetTablePost(table: string, body?: { [key: string]: JToken; }, options?: AxiosRequestConfig) : Promise<AxiosResponse<AdminResultJObject>> {
        return APIJSONApiFp(this.configuration).apiAPIJSONGetTablePost(table, body, options).then((request) => request(this.axios, this.basePath));
    }
    /**
     * 
     * @summary 修改（只支持Id作为条件）
     * @param {{ [key: string]: JToken; }} [body] 支持多表、多Id批量更新
     * @param {*} [options] Override http request option.
     * @throws {RequiredError}
     * @memberof APIJSONApi
     */
    public async apiAPIJSONUpdatePost(body?: { [key: string]: JToken; }, options?: AxiosRequestConfig) : Promise<AxiosResponse<AdminResultJObject>> {
        return APIJSONApiFp(this.configuration).apiAPIJSONUpdatePost(body, options).then((request) => request(this.axios, this.basePath));
    }
}
