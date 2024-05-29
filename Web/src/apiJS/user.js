import request from '../utilsJS/request.js'

export const useAddUserService = ({ obj }) => {
    return request.post('/api/frontEndUser/addUser', { obj })
}