<script setup>
import { useRouter } from 'vue-router';
import { ref, onMounted } from 'vue'
import { UserApi } from '/@/api/frontend/User';
const props = defineProps({
  obj: Object,
  // eslint-disable-next-line vue/no-reserved-props
  key:String,
  flag:Number
})
const formModel = ref()
formModel.value = props.obj

let powers = ref([])
let selectionKeys = ref([])
onMounted(() => {
  powers.value=formModel.value.powers
  selectionKeys = ref(
      powers.value.filter((power) => power.status).map((power) => power.id)
  )
})
const multipleTable = ref(null)
onMounted(() => {
  selectionKeys.value.forEach((key) => {
    powers.value.forEach((row) => {
      if (row.id == key) {
        multipleTable.value.toggleRowSelection(row, true)
      }
    })
  })
})
const handleSelectionChange = (val) => {
  selectionKeys.value = val.map((item) => item.id)
  console.log(selectionKeys.value);
}

const router=useRouter()
const handleConfirm = () => {
  formModel.value.powers = selectionKeys.value
  if(props.flag===0){
    UserApi().addUser(formModel.value.user)
  }else{
    //编辑的接口
  }
  router.go(0)
  console.log(formModel.value);
}
</script>
<template>
  <el-scrollbar height="550px">
    <el-form :model="formModel">
      <el-form-item label="姓名">
        <el-input v-model="formModel.user.name"></el-input>
      </el-form-item>
      <el-form-item label="密码">
        <el-input v-model="formModel.user.userPassword"></el-input>
      </el-form-item>
      <el-form-item label="备注">
        <el-input v-model="formModel.user.remark"></el-input>
      </el-form-item>
      <el-form-item label="状态">
        <el-radio-group v-model="formModel.user.status">
          <el-radio :value="1" size="large">正常</el-radio>
          <el-radio :value="0" size="large">禁用</el-radio>
        </el-radio-group>
      </el-form-item>
      <el-form-item>
        <el-select
            v-model="value"
            multiple
            filterable
            remote
            reserve-keyword
            placeholder="请输入权限名称"
            :remote-method="remoteMethod"
            :loading="loading"
            style="width: 240px; margin-bottom: 20px"
        >
          <el-option
              v-for="item in options"
              :key="item.value"
              :label="item.label"
              :value="item.value"
          />
        </el-select>
        <el-table
            :data="formModel.powers"
            row-key="id"
            border
            ref="multipleTable"
            @selection-change="handleSelectionChange"
        >
          >
          <el-table-column
              type="selection"
              width="55"
              :reserve-selection="true"
          />
          <el-table-column
              type="index"
              label="序号"
              width="80"
          ></el-table-column>
          <el-table-column label="权限名称" prop="name"> </el-table-column>
        </el-table>
      </el-form-item>
      <el-form-item>
        <div style="display: flex; justify-content: right; width: 100%">
          <el-button type="primary" @click="handleConfirm">确认</el-button>
        </div>
      </el-form-item>
    </el-form>
  </el-scrollbar>
</template>
<style lang="scss" scoped>
.el-form {
  padding: 20px;
}
</style>
