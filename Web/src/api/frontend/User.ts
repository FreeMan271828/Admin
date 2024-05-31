import request from '/@/utils/request';

//修改密码参数
class changePwdParam{
    userId = 0;
    oldPassword = "";
    newPassword = "";
}
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


export function UserApi() {
    return {
        /**
         * 添加用户
         * @param data user对象
         */
        addUser: (data: object) => {
            return request({
                url: 'api/frontEndUser/addUser',
                method : 'post',
                data,
            })
        },
        /**
         * 删除用户
         * @param data id
         */
        deleteUserById: (data: number) =>{
            console.log(data);
            return request({
                url: `api/frontEndUser/delUserById`,
                method: 'post',
                data,
            })
        },
        /**
         * 修改用户信息
         * @param data 用户对象
         */
        changeUserInfo:(data: object) => {
            return request({
                url : 'api/frontEndUser/changeUserInfo',
                method : 'post',
                data,
            })
        },
        /**
         * 获取全部用户
         */
        getAllUser()  {
            return request({
                url:'api/frontEndUser/getAllUsers',
                method: 'get',
            })
        },
        /**
         * 根据id 和 name 获取用户
         * @param data userId name
         */
        getUserByParam: (data: getParam) => {
            return request({
                url: `api/frontEndUser/getUser`,
                method:'get',
                data:data,
            })
        },
        /**
         * 分页查询全部用户
         * @param data pageIndex（页面索引） pageSize（页面大小）
         */
        getAllUserInPage : (data : pageParam) => {
          return request({
              url : `api/frontEndUser/getAllUsersInPage`,
              method:'get',
              data:data,
          })
        },
        /**
         * 修改密码
         * @param data  userId oldPassword newPassword
         */
        changePassword: (data: changePwdParam) => {
            return request({
                url : `api/frontEndUser/changePassword`,
                method:'post',
                data,
            })
        },
        /**
         * 重置密码
         * @param data id
         */
        resetPassword: (data: number) => {
            return request({
                url: `api/frontEndUser/resetPassword`,
                method:'post',
                data:data,
            })
        }
    };
}