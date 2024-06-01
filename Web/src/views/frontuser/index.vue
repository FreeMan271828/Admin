<script setup>
import {Plus, Refresh, Search} from '@element-plus/icons-vue'
import {onMounted, ref} from 'vue'
import editUser from '/@/views/frontuser/component/editUser.vue'
import {UserApi} from "/@/api/frontend/User.ts";
// import {UserPowerApi} from "/@/api/frontend/UserPower.ts";

onMounted(() => {
  handleQuery()
  // console.log(tableParams.value.userData[0].powers)
})
const getNewTable=async ({pageIndex,pageSize})=>{
  const response = await UserApi().getAllInfoInPage({pageIndex,pageSize});
  tableParams.value.userData=response.data.result; 
  const res= await UserApi().getAllUserInPage({pageIndex,pageSize});
  tableParams.value.page=res.data.result.page;
  tableParams.value.pageSize=res.data.result.pageSize;
  tableParams.value.total=res.data.result.total;
  console.log(response)
}

const tableParams = ref({
  userData:  [],
  page: 1,
  pageSize: 10,
  total: 0
})

const searchForm = ref('')
const searchFormValue = ref({
  id: '',
  name: ''
})
const Reset = () => {
  console.log('重置')
  searchForm.value.resetFields()
}

const handleQuery = async () => {
  console.log('查询')
  await getNewTable({pageIndex:1,pageSize:10})
}

const handleSizeChange =async (val) => {
  console.log(`每页 ${val} 条`)
  getNewTable({pageIndex:tableParams.value.page,pageSize:val})
}
const handleCurrentChange = (val) => {
  console.log(`当前页: ${val}`)
  getNewTable({pageIndex:val,pageSize:tableParams.value.pageSize})
}

const dialogVisible1 = ref(false)
const dia_index1 = ref(0)
const rowClick = (row) => {
  dia_index1.value = tableParams.value.userData.indexOf(row)
}
const handleDetail = () => {
  dialogVisible1.value = true
  console.log(dia_index1.value)
}

const dialogVisible3 = ref(false)
const delId=ref(0)
const clickDel = (index) => {
  delId.value=index
  dialogVisible3.value = true
}
const handleDel = async () => {
  console.log(tableParams.value.userData[delId.value].user.id);
  const res=await UserApi().deleteUserById(tableParams.value.userData[delId.value].user.id)
  console.log(res);
  dialogVisible3.value = false
  getNewTable({pageIndex:tableParams.value.page,pageSize:tableParams.value.pageSize})
}

const diaProps1 = ref([])

const diaProps2 = ref({
  user:{
    name: '',
    password: '',
    remark: '',
    status: true,
  },
  powers: [
    {
      name: 'test1',
      id: 1,
      status: false
    },
    {
      name: 'test2',
      id: 2,
      status: false
    },
    {
      name: 'test3',
      id: 3,
      status: false
    },
    {
      name: 'test4',
      id: 4,
      status: false
    },
    {
      name: 'test5',
      id: 5,
      status: false
    },
    {
      name: 'test6',
      id: 6,
      status: false
    }
  ]
})
const dialogVisible2 = ref(false)
const diaTitle = ref('')
const useChoiceBox = (e,index) => {
  dialogVisible2.value = true
  diaTitle.value = e.target.innerText
  diaProps1.value=tableParams.value.userData[index]
}
</script>

<template>
  <div style="height: 100%;display: flex;flex-direction: column;">
    <el-card>
      <el-form style="display: flex;" ref="searchForm" :model="searchFormValue"  class="form1">
        <el-form-item label="ID" prop="id">
          <el-select
            v-model="searchFormValue.id"
            multiple
            filterable
            remote
            reserve-keyword
            placeholder="ID"
            :remote-method="remoteMethod"
            :loading="loading"
            style="width: 240px"
          >
            <el-option
              v-for="item in options"
              :key="item.value"
              :label="item.label"
              :value="item.value"
            />
          </el-select>
        </el-form-item>
        <el-form-item label="姓名" prop="name">
          <el-select
            v-model="searchFormValue.name"
            multiple
            filterable
            remote
            reserve-keyword
            placeholder="姓名"
            :remote-method="remoteMethod"
            :loading="loading"
            style="width: 240px"
          >
            <el-option
              v-for="item in options"
              :key="item.value"
              :label="item.label"
              :value="item.value"
            />
          </el-select>
        </el-form-item>
        <el-form-item>
          <el-button type="primary" :icon="Search">搜索</el-button>
          <el-button type="primary" :icon="Refresh" @click="Reset"
          >重置</el-button
          >
          <el-button type="primary" :icon="Plus" @click="useChoiceBox"
          >新增</el-button
          >
        </el-form-item>
      </el-form>
    </el-card>
    <el-card style="height: 100%;position: relative;">
        <el-table border :data="tableParams.userData" @row-click="rowClick">
          <el-table-column type="index" label="序号" width="80"></el-table-column>
          <el-table-column label="姓名" prop="user.name"></el-table-column>
          <el-table-column label="密码" prop="user.userPassword"></el-table-column>
          <el-table-column label="权限" prop="user.powers">
            <template v-slot="scope">
              <div style="display: flex; justify-content: space-around">
                <el-tag
                    v-for="item in tableParams.userData[scope.$index].powers"
                    :key="item"
                >{{ item.name }}</el-tag
                >
              </div>
            </template>
          </el-table-column>
          <el-table-column label="状态" >
            <template v-slot="scope">
              <el-tag :type="scope.row.user.status ? 'success' : 'danger'">{{
                  scope.row.user.status ? '正常' : '禁用'
                }}</el-tag>
            </template>
          </el-table-column>
          <el-table-column label="操作" class="operate">
            <template v-slot="scope">
              <div style="display: flex; justify-content: space-around">
                <el-button type="success" @click="handleDetail">详情</el-button>
                <el-button type="primary" @click="useChoiceBox($event,scope.$index)">编辑</el-button>
                <el-button type="danger" @click="clickDel(scope.$index)">删除</el-button>
              </div>
            </template>
          </el-table-column>
        </el-table>
        <el-pagination
            style="position: absolute;bottom: 30px;left: 45vw;"
            v-model:currentPage="tableParams.page"
            v-model:page-size="tableParams.pageSize"
            :total="tableParams.total"
            :page-sizes="[5,10]"
            small
            background
            @size-change="handleSizeChange"
            @current-change="handleCurrentChange"
            layout="total, sizes, prev, pager, next, jumper"
        />
      </el-card>
    <el-dialog v-model="dialogVisible1" title="详情">
      <div style="height: 200px">
        <el-form
            style="
            height: 100%;
            display: flex;
            flex-direction: column;
            justify-content: space-around;
            align-items: center;
          "
        >
          <el-form-item label="姓名">
            <el-input v-model="tableParams.userData[dia_index1].user.name"></el-input>
          </el-form-item>
          <el-form-item label="密码">
            <el-input
                v-model="tableParams.userData[dia_index1].user.userPassword"
            ></el-input>
          </el-form-item>
          <el-form-item label="权限">
            <el-input
                :disabled="true"
                type="textarea"
                :value="tableParams.userData[dia_index1].powers.map(power=>power.name).join('\n')"
            ></el-input>
          </el-form-item>
          <el-form-item label="备注">
            <el-input
                v-model="tableParams.userData[dia_index1].user.remark"
            ></el-input>
          </el-form-item>
          <el-form-item label="状态">
            <el-tag
                :type="
                tableParams.userData[dia_index1].user.status ? 'success' : 'danger'
              "
            >
              {{ tableParams.userData[dia_index1].user.status ? '正常' : '禁用' }}
            </el-tag>
          </el-form-item>
        </el-form>
      </div>
    </el-dialog>
    <el-dialog v-model="dialogVisible2" :title="diaTitle">
      <editUser :obj="diaProps1" v-if="diaTitle === '编辑'" :key="new Date().getTime()"></editUser>
      <editUser :obj="diaProps2" v-else :key="new Date().getDate()" ></editUser>
    </el-dialog>
    <el-dialog
      v-model="dialogVisible3"
      title="删除用户"
      width="500"
    >
    <span>确定要删除该用户吗?</span>
    <template #footer>
      <div class="dialog-footer">
        <el-button @click="dialogVisible3 = false">取消</el-button>
        <el-button type="primary" @click="handleDel">
          确认
        </el-button>
      </div>
    </template>
  </el-dialog>
  </div>
</template>

<style lang="scss" scoped>
.el-form-item {
  margin: auto 0 auto 20px;
}
.el-card {
  margin: 5px;

}
.operate {
  display: flex;
  justify-content: space-around;
}
</style>

<!--<script setup>-->
<!--import { ref } from 'vue'-->
<!--import {UserApi} from '/src/api/frontend/User'-->
<!--const formModel = ref({-->
<!--  name: '',-->
<!--  userPassword: '',-->
<!--  remark: ''-->
<!--})-->
<!--const onClick = async () => {-->
<!--  await UserApi().addUser({-->
<!--    name: formModel.value.name,-->
<!--    userPassword: formModel.value.userPassword,-->
<!--    remark: formModel.value.remark-->
<!--  });-->
<!--  console.log(formModel.value)-->
<!--}-->

<!--const userId = ref(0)-->
<!--const newPassword = ref('')-->
<!--const userInfo = ref({-->
<!--  name: '',-->
<!--  userPassword: '',-->
<!--  remark: ''-->
<!--})-->
<!--const getUserInfo = async () => {-->
<!--  const res=await UserApi().getUserByParam(userId.value)-->
<!--  userInfo.value=res.data.result-->
<!--}-->
<!--const onDel= async ()=>{-->
<!--  console.log(userId.value)-->
<!--  await UserApi().deleteUserById(userId.value)-->
<!--  userId.value = 0;-->
<!--}-->
<!--const onChangeInfo=async ()=>{-->
<!--  await UserApi().changeUserInfo(userInfo.value);-->
<!--  userId.value = 0;-->
<!--}-->
<!--const onChangePassword=async ()=>{-->
<!--  await UserApi().changePassword({-->
<!--    userId:userId.value,-->
<!--    oldPassword:userInfo.value.userPassword,-->
<!--    newPassword:newPassword.value-->
<!--  })-->
<!--  userId.value = 0;-->
<!--}-->
<!--const onReset= async ()=>{-->
<!--  await UserApi().resetPassword(userId.value);-->
<!--  userId.value = 0;-->
<!--}-->
<!--</script>-->

<!--<template>-->
<!--  <div class="box">-->
<!--    <el-tabs>-->
<!--      <el-tab-pane label="AddUser">-->
<!--        <div class="form1 flex">-->
<!--          <el-form>-->
<!--            <el-form-item label="姓名">-->
<!--              <el-input-->
<!--                  size="large"-->
<!--                  v-model="formModel.name"-->
<!--                  placeholder="请输入姓名"-->
<!--              ></el-input>-->
<!--            </el-form-item>-->
<!--            <el-form-item label="密码">-->
<!--              <el-input-->
<!--                  size="large"-->
<!--                  v-model="formModel.userPassword"-->
<!--                  placeholder="请输入密码"-->
<!--              ></el-input>-->
<!--            </el-form-item>-->
<!--            <el-form-item label="备注">-->
<!--              <el-input-->
<!--                  size="large"-->
<!--                  v-model="formModel.remark"-->
<!--                  placeholder="请输入备注"-->
<!--              ></el-input>-->
<!--            </el-form-item>-->
<!--            <el-form-item>-->
<!--              <div style="width: 100%; text-align: center">-->
<!--                <el-button type="primary" @click="onClick">添加</el-button>-->
<!--              </div>-->
<!--            </el-form-item>-->
<!--          </el-form>-->
<!--        </div>-->
<!--      </el-tab-pane>-->
<!--      <el-tab-pane label="DelUser">-->
<!--        <div class="flex">-->
<!--          <el-form class="form2">-->
<!--            <el-form-item label="UserId">-->
<!--              <div style="margin-right: 20px">-->
<!--                <el-input placeholder="请输入用户ID" v-model="userId" size="large"></el-input>-->
<!--              </div>-->
<!--              <el-button type="primary" @click="getUserInfo">搜索</el-button>-->
<!--            </el-form-item>-->
<!--            <div class="box">-->
<!--              <el-form-item label="姓名">-->
<!--                <el-input :disabled="true" v-model="userInfo.name" size="large"></el-input>-->
<!--              </el-form-item>-->
<!--              <el-form-item label="密码">-->
<!--                <el-input :disabled="true" v-model="userInfo.userPassword" size="large"></el-input>-->
<!--              </el-form-item>-->
<!--              <el-form-item label="备注">-->
<!--                <el-input :disabled="true" v-model="userInfo.remark" size="large"></el-input>-->
<!--              </el-form-item>-->
<!--              <el-form-item>-->
<!--                <div style="text-align: center; width: 100%">-->
<!--                  <el-button type="primary" @click="onDel">确认删除</el-button>-->
<!--                </div>-->
<!--              </el-form-item>-->
<!--            </div>-->
<!--          </el-form>-->
<!--        </div>-->
<!--      </el-tab-pane>-->
<!--      <el-tab-pane label="ChangeUserInfo">-->
<!--        <div class="flex">-->
<!--          <el-form class="form2">-->
<!--            <el-form-item label="UserId">-->
<!--              <div style="margin-right: 20px">-->
<!--                <el-input placeholder="请输入用户ID" v-model="userId" size="large"></el-input>-->
<!--              </div>-->
<!--              <el-button type="primary" @click="getUserInfo">搜索</el-button>-->
<!--            </el-form-item>-->
<!--            <div class="box">-->
<!--              <el-form-item label="姓名">-->
<!--                <el-input v-model="userInfo.name" size="large"></el-input>-->
<!--              </el-form-item>-->
<!--              <el-form-item label="密码">-->
<!--                <el-input v-model="userInfo.userPassword" size="large"></el-input>-->
<!--              </el-form-item>-->
<!--              <el-form-item label="备注">-->
<!--                <el-input v-model="userInfo.remark" size="large"></el-input>-->
<!--              </el-form-item>-->
<!--              <el-form-item>-->
<!--                <div style="text-align: center; width: 100%">-->
<!--                  <el-button type="primary" @click="onChangeInfo">确认修改</el-button>-->
<!--                </div>-->
<!--              </el-form-item>-->
<!--            </div>-->
<!--          </el-form>-->
<!--        </div>-->
<!--      </el-tab-pane>-->
<!--      <el-tab-pane label="ChangePwd">-->
<!--        <div class="flex">-->
<!--          <el-form class="form4">-->
<!--            <el-form-item label="UserId">-->
<!--              <div style="margin-right: 20px">-->
<!--                <el-input placeholder="请输入用户ID" v-model="userId"></el-input>-->
<!--              </div>-->
<!--              <el-button type="primary" @click="getUserInfo">搜索</el-button>-->
<!--            </el-form-item>-->
<!--            <div class="box">-->
<!--              <el-form-item label="原密码">-->
<!--                <el-input :disabled="true" v-model="userInfo.userPassword" size="large"></el-input>-->
<!--              </el-form-item>-->
<!--              <el-form-item label="新密码">-->
<!--                <el-input v-model="newPassword" size="large"></el-input>-->
<!--              </el-form-item>-->
<!--              <el-form-item>-->
<!--                <div style="text-align: center; width: 100%">-->
<!--                  <el-button type="primary" @click="onChangePassword">确认修改</el-button>-->
<!--                </div>-->
<!--              </el-form-item>-->
<!--            </div>-->
<!--          </el-form>-->
<!--        </div>-->
<!--      </el-tab-pane>-->
<!--      <el-tab-pane label="ResetPwd">-->
<!--        <div class="flex form5">-->
<!--          <el-form>-->
<!--            <el-form-item label="UserId">-->
<!--              <div style="margin-right: 20px">-->
<!--                <el-input placeholder="请输入用户ID" v-model="userId" size="large"></el-input>-->
<!--              </div>-->
<!--              <el-button type="primary" @click="getUserInfo">搜索</el-button>-->
<!--            </el-form-item>-->
<!--            <el-form-item label="用户姓名">-->
<!--              <div style="margin-right: 20px">-->
<!--                <el-input :disabled="true" v-model="userInfo.name" size="large"></el-input>-->
<!--              </div>-->
<!--              <el-button type="primary" @click="onReset">确认重置</el-button>-->
<!--            </el-form-item>-->
<!--          </el-form>-->
<!--        </div>-->
<!--      </el-tab-pane>-->
<!--    </el-tabs>-->
<!--  </div>-->
<!--</template>-->
<!--<style lang="scss" scoped>-->
<!--.box {-->
<!--  margin-left: 20px;-->
<!--  .form1 {-->
<!--    padding: 30px;-->
<!--    border-radius: 20px;-->
<!--    border: 3px solid black;-->
<!--    width: 50%;-->
<!--  }-->
<!--  .form2 {-->
<!--    .box {-->
<!--      padding: 30px;-->
<!--      border-radius: 20px;-->
<!--      border: 3px solid black;-->
<!--      width: 50%;-->
<!--    }-->
<!--  }-->
<!--  .form4 {-->
<!--    .box {-->
<!--      padding: 30px;-->
<!--      border-radius: 20px;-->
<!--      border: 3px solid black;-->
<!--      width: 50%;-->
<!--    }-->
<!--  }-->
<!--  .form5{-->
<!--    padding: 30px;-->
<!--    border-radius: 20px;-->
<!--    border: 3px solid black;-->
<!--    width: 50%;-->
<!--  }-->
<!--  .flex{-->
<!--    width: 50%;-->
<!--    height: 50%;-->
<!--    display: flex;-->
<!--    flex-direction: column;-->
<!--    align-content: center;-->
<!--    justify-content: center;-->
<!--  }-->
<!--  .el-tab-pane {-->
<!--    display: flex;-->
<!--    margin: auto 0;-->
<!--    align-content: center;-->
<!--    justify-content: center;-->
<!--  }-->
<!--}-->
<!--</style>-->