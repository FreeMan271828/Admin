<template>
  <div class="sysCodeGenConfig-container">
    <el-card shadow="hover" :body-style="{ paddingBottom: '0' }">
      <el-form :model="queryParams" ref="queryForm" labelWidth="90">
        <el-row>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10">
            <el-form-item label="关键字">
              <el-input v-model="queryParams.searchKey" clearable="" placeholder="请输入模糊查询关键字"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="主表Id">
              <el-input v-model="queryParams.codeGenId" clearable="" placeholder="请输入主表Id"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="字段名称">
              <el-input v-model="queryParams.columnName" clearable="" placeholder="请输入字段名称"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="属性名称">
              <el-input v-model="queryParams.propertyName" clearable="" placeholder="请输入属性名称"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="字段数据长度">
              <el-input v-model="queryParams.columnLength" clearable="" placeholder="请输入字段数据长度"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="字段描述">
              <el-input v-model="queryParams.columnComment" clearable="" placeholder="请输入字段描述"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="NET数据类型">
              <el-input v-model="queryParams.netType" clearable="" placeholder="请输入NET数据类型"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="作用类型">
              <el-input v-model="queryParams.effectType" clearable="" placeholder="请输入作用类型"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="外键实体名称">
              <el-input v-model="queryParams.fkEntityName" clearable="" placeholder="请输入外键实体名称"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="外键表名称">
              <el-input v-model="queryParams.fkTableName" clearable="" placeholder="请输入外键表名称"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="外键显示字段">
              <el-input v-model="queryParams.fkColumnName" clearable="" placeholder="请输入外键显示字段"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="外键显示字段.NET类型">
              <el-input v-model="queryParams.fkColumnNetType" clearable="" placeholder="请输入外键显示字段.NET类型"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="字典编码">
              <el-input v-model="queryParams.dictTypeCode" clearable="" placeholder="请输入字典编码"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="列表是否缩进">
              <el-input v-model="queryParams.whetherRetract" clearable="" placeholder="请输入列表是否缩进"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="是否必填">
              <el-input v-model="queryParams.whetherRequired" clearable="" placeholder="请输入是否必填"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="是否可排序">
              <el-input v-model="queryParams.whetherSortable" clearable="" placeholder="请输入是否可排序"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="是否是查询条件">
              <el-input v-model="queryParams.queryWhether" clearable="" placeholder="请输入是否是查询条件"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="查询方式">
              <el-input v-model="queryParams.queryType" clearable="" placeholder="请输入查询方式"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="列表显示">
              <el-input v-model="queryParams.whetherTable" clearable="" placeholder="请输入列表显示"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="增改">
              <el-input v-model="queryParams.whetherAddUpdate" clearable="" placeholder="请输入增改"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="主键">
              <el-input v-model="queryParams.columnKey" clearable="" placeholder="请输入主键"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="数据库中类型">
              <el-input v-model="queryParams.dataType" clearable="" placeholder="请输入数据库中类型"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="是否通用字段">
              <el-input v-model="queryParams.whetherCommon" clearable="" placeholder="请输入是否通用字段"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="显示文本字段">
              <el-input v-model="queryParams.displayColumn" clearable="" placeholder="请输入显示文本字段"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="选中值字段">
              <el-input v-model="queryParams.valueColumn" clearable="" placeholder="请输入选中值字段"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="父级字段">
              <el-input v-model="queryParams.pidColumn" clearable="" placeholder="请输入父级字段"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="4" class="mb10" v-if="showAdvanceQueryUI">
            <el-form-item label="排序">
              <el-input v-model="queryParams.orderNo" clearable="" placeholder="请输入排序"/>
              
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="6" :xl="6" class="mb10">
            <el-form-item>
              <el-button-group style="display: flex; align-items: center;">
                <el-button type="primary"  icon="ele-Search" @click="handleQuery" v-auth="'sysCodeGenConfig:page'"> 查询 </el-button>
                <el-button icon="ele-Refresh" @click="() => queryParams = {}"> 重置 </el-button>
                <el-button icon="ele-ZoomIn" @click="changeAdvanceQueryUI" v-if="!showAdvanceQueryUI" style="margin-left:5px;"> 高级查询 </el-button>
                <el-button icon="ele-ZoomOut" @click="changeAdvanceQueryUI" v-if="showAdvanceQueryUI" style="margin-left:5px;"> 隐藏 </el-button>
                <el-button type="primary" style="margin-left:5px;" icon="ele-Plus" @click="openAddSysCodeGenConfig" v-auth="'sysCodeGenConfig:add'"> 新增 </el-button>
                
              </el-button-group>
            </el-form-item>
            
          </el-col>
        </el-row>
      </el-form>
    </el-card>
    <el-card class="full-table" shadow="hover" style="margin-top: 5px">
      <el-table
				:data="tableData"
				style="width: 100%"
				v-loading="loading"
				tooltip-effect="light"
				row-key="id"
                @sort-change="sortChange"
				border="">
        <el-table-column type="index" label="序号" width="55" align="center"/>
        <el-table-column prop="codeGenId" label="主表Id" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="columnName" label="字段名称" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="propertyName" label="属性名称" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="columnLength" label="字段数据长度" width="90"  show-overflow-tooltip="" />
        <el-table-column prop="columnComment" label="字段描述" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="netType" label="NET数据类型" width="105"  show-overflow-tooltip="" />
        <el-table-column prop="effectType" label="作用类型" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="fkEntityName" label="外键实体名称" width="90"  show-overflow-tooltip="" />
        <el-table-column prop="fkTableName" label="外键表名称" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="fkColumnName" label="外键显示字段" width="90"  show-overflow-tooltip="" />
        <el-table-column prop="fkColumnNetType" label="外键显示字段.NET类型" width="180"  show-overflow-tooltip="" />
        <el-table-column prop="dictTypeCode" label="字典编码" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="whetherRetract" label="列表是否缩进" width="90"  show-overflow-tooltip="" />
        <el-table-column prop="whetherRequired" label="是否必填" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="whetherSortable" label="是否可排序" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="queryWhether" label="是否是查询条件" width="105"  show-overflow-tooltip="" />
        <el-table-column prop="queryType" label="查询方式" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="whetherTable" label="列表显示" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="whetherAddUpdate" label="增改" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="columnKey" label="主键" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="dataType" label="数据库中类型" width="90"  show-overflow-tooltip="" />
        <el-table-column prop="whetherCommon" label="是否通用字段" width="90"  show-overflow-tooltip="" />
        <el-table-column prop="displayColumn" label="显示文本字段" width="90"  show-overflow-tooltip="" />
        <el-table-column prop="valueColumn" label="选中值字段" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="pidColumn" label="父级字段" width="140"  show-overflow-tooltip="" />
        <el-table-column prop="orderNo" label="排序" width="140"  show-overflow-tooltip="" />
        <el-table-column label="操作" width="140" align="center" fixed="right" show-overflow-tooltip="" v-if="auth('sysCodeGenConfig:update') || auth('sysCodeGenConfig:delete')">
          <template #default="scope">
            <el-button icon="ele-Edit" size="small" text="" type="primary" @click="openEditSysCodeGenConfig(scope.row)" v-auth="'sysCodeGenConfig:update'"> 编辑 </el-button>
            <el-button icon="ele-Delete" size="small" text="" type="primary" @click="delSysCodeGenConfig(scope.row)" v-auth="'sysCodeGenConfig:delete'"> 删除 </el-button>
          </template>
        </el-table-column>
      </el-table>
      <el-pagination
				v-model:currentPage="tableParams.page"
				v-model:page-size="tableParams.pageSize"
				:total="tableParams.total"
				:page-sizes="[10, 20, 50, 100, 200, 500]"
				small=""
				background=""
				@size-change="handleSizeChange"
				@current-change="handleCurrentChange"
				layout="total, sizes, prev, pager, next, jumper"
	/>
      <printDialog
        ref="printDialogRef"
        :title="printSysCodeGenConfigTitle"
        @reloadTable="handleQuery" />
      <editDialog
        ref="editDialogRef"
        :title="editSysCodeGenConfigTitle"
        @reloadTable="handleQuery"
      />
    </el-card>
  </div>
</template>

<script lang="ts" setup="" name="sysCodeGenConfig">
  import { ref } from "vue";
  import { ElMessageBox, ElMessage } from "element-plus";
  import { auth } from '/@/utils/authFunction';
  import { getDictDataItem as di, getDictDataList as dl } from '/@/utils/dict-utils';
  import { formatDate } from '/@/utils/formatTime';


  import printDialog from '/@/views/system/print/component/hiprint/preview.vue'
  import editDialog from '/@/views/main/sysCodeGenConfig/component/editDialog.vue'
  import { pageSysCodeGenConfig, deleteSysCodeGenConfig } from '/@/api/main/sysCodeGenConfig';


  const showAdvanceQueryUI = ref(false);
  const printDialogRef = ref();
  const editDialogRef = ref();
  const loading = ref(false);
  const tableData = ref<any>([]);
  const queryParams = ref<any>({});
  const tableParams = ref({
    page: 1,
    pageSize: 10,
    total: 0,
  });

  const printSysCodeGenConfigTitle = ref("");
  const editSysCodeGenConfigTitle = ref("");

  // 改变高级查询的控件显示状态
  const changeAdvanceQueryUI = () => {
    showAdvanceQueryUI.value = !showAdvanceQueryUI.value;
  }
  

  // 查询操作
  const handleQuery = async () => {
    loading.value = true;
    var res = await pageSysCodeGenConfig(Object.assign(queryParams.value, tableParams.value));
    tableData.value = res.data.result?.items ?? [];
    tableParams.value.total = res.data.result?.total;
    loading.value = false;
  };

  // 列排序
  const sortChange = async (column: any) => {
	queryParams.value.field = column.prop;
	queryParams.value.order = column.order;
	await handleQuery();
  };

  // 打开新增页面
  const openAddSysCodeGenConfig = () => {
    editSysCodeGenConfigTitle.value = '添加代码生成字段配置表';
    editDialogRef.value.openDialog({});
  };

  // 打开打印页面
  const openPrintSysCodeGenConfig = async (row: any) => {
    printSysCodeGenConfigTitle.value = '打印代码生成字段配置表';
  }
  
  // 打开编辑页面
  const openEditSysCodeGenConfig = (row: any) => {
    editSysCodeGenConfigTitle.value = '编辑代码生成字段配置表';
    editDialogRef.value.openDialog(row);
  };

  // 删除
  const delSysCodeGenConfig = (row: any) => {
    ElMessageBox.confirm(`确定要删除吗?`, "提示", {
    confirmButtonText: "确定",
    cancelButtonText: "取消",
    type: "warning",
  })
  .then(async () => {
    await deleteSysCodeGenConfig(row);
    handleQuery();
    ElMessage.success("删除成功");
  })
  .catch(() => {});
  };

  // 改变页面容量
  const handleSizeChange = (val: number) => {
    tableParams.value.pageSize = val;
    handleQuery();
  };

  // 改变页码序号
  const handleCurrentChange = (val: number) => {
    tableParams.value.page = val;
    handleQuery();
  };

  handleQuery();
</script>
<style scoped>
:deep(.el-ipnut),
:deep(.el-select),
:deep(.el-input-number) {
	width: 100%;
}
</style>

