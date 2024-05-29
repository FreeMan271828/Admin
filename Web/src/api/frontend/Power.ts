import request from '/@/utils/request';

//获取请求参数
class getParam{
    userId : number = 0;    //用户Id
    name : string = "";     //用户名称
}
//分页查询参数
class pageParam{
    pageIndex: number = 0;  //分页索引
    pageSize: number = 0;   //分页大小
}

export function PowerApi() {
    return {
        /**
         * 增加权限
         * @param data
         */
        addPower(data : object) {
            return request({
                url : 'api/powerBase/addPower',
                method:'post',
                data : data,
            })
        },
        /**
         * 修改权限
         * @param data
         */
        changePower(data : object) {
            return request({
                url : 'api/powerBase/changePower',
                method:'post',
                data : data,
            })
        },
        /**
         * 根据id删除权限
         * @param data
         */
        deletePowerById(data : object) {
            return request({
                url : 'api/powerBase/delPowerById',
                method:'post',
                data : data,
            })
        },
        /**
         * 根据id或姓名获取权限
         * @param data
         */
        getPowerByParam(data : getParam) {
            return request({
                url : `api/powerBase/getPowerByParam`,
                method: 'post',
                data : data,
            })
        },
        /**
         * 获取全部权限
         */
        getAllPower() {
            return request({
                url: 'api/powerBase/getAllPowers',
                method: 'get',
            })
        },
        /**
         * 分页查询全部权限
         * @param data pageIndex pageSize
         */
        getAllPowerInPage(data : pageParam) {
            return request({
                url : `api/powerBase/getAllPowersInPage`,
                method: 'get',
                data: data,
            })
        }
    };
}