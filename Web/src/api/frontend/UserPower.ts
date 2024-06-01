import request from '/@/utils/request';
class unitId{
    userId : number = 0;
    powerId : number = 0;
}
export function UserPowerApi() {
    return {
        /**
         * 为用户添加权限
         * @param data 用户Id, 权限Id
         */
       addUserPower: (data: unitId) => {
            return request({
                url: 'api/userPower/addUserPower',
                method:'post',
                data
            })
       },
        /**
         * 为用户删除权限
         * @param data 用户Id，权限Id
         */
        deleteUserPower(data : unitId) {
           return request({
               url: 'api/userPower/delUserPower',
               method:'post',
               data : data,
           })
        },
        /**
         * 获取全部的用户权限
         */
        getAllUserPower(){
            return request({
                url : 'api/userPower/getAllUserPower',
                method : 'get',
            })
        },
        /**
         * 根据用户id获取权限
         * 待维护
         */
        getPowersByUserId( data : number) {
            return request({
                url : 'api/userPower/getPowerByUserId',
                method:'get',
                data : data,
            })
        },
        /**
         * 获取用户和权限的全部信息
         */
        getAllInfo(){
            return request({
                url : 'api/userPower/getAllInfo',
                method: 'get',
            })
        }
    };
}