<template>
	<div class="sysCodeGenConfig-container">
		<el-dialog v-model="isShowDialog" :width="800" draggable="">
			<template #header>
				<div style="color: #fff">
					<!--<el-icon size="16" style="margin-right: 3px; display: inline; vertical-align: middle"> <ele-Edit /> </el-icon>-->
					<span>{{ props.title }}</span>
				</div>
			</template>
			<el-form :model="ruleForm" ref="ruleFormRef" label-width="auto" :rules="rules">
				<el-row :gutter="35">
					<el-form-item v-show="false">
						<el-input v-model="ruleForm.id" />
					</el-form-item>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="主表Id" prop="codeGenId">
							<el-input v-model="ruleForm.codeGenId" placeholder="请输入主表Id" maxlength="0" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="字段名称" prop="columnName">
							<el-input v-model="ruleForm.columnName" placeholder="请输入字段名称" maxlength="128" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="属性名称" prop="propertyName">
							<el-input v-model="ruleForm.propertyName" placeholder="请输入属性名称" maxlength="128" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="字段数据长度" prop="columnLength">
							<el-input v-model="ruleForm.columnLength" placeholder="请输入字段数据长度" maxlength="0" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="字段描述" prop="columnComment">
							<el-input v-model="ruleForm.columnComment" placeholder="请输入字段描述" maxlength="128" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="NET数据类型" prop="netType">
							<el-input v-model="ruleForm.netType" placeholder="请输入NET数据类型" maxlength="64" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="作用类型" prop="effectType">
							<el-input v-model="ruleForm.effectType" placeholder="请输入作用类型" maxlength="64" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="外键实体名称" prop="fkEntityName">
							<el-input v-model="ruleForm.fkEntityName" placeholder="请输入外键实体名称" maxlength="64" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="外键表名称" prop="fkTableName">
							<el-input v-model="ruleForm.fkTableName" placeholder="请输入外键表名称" maxlength="128" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="外键显示字段" prop="fkColumnName">
							<el-input v-model="ruleForm.fkColumnName" placeholder="请输入外键显示字段" maxlength="64" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="外键显示字段.NET类型" prop="fkColumnNetType">
							<el-input v-model="ruleForm.fkColumnNetType" placeholder="请输入外键显示字段.NET类型" maxlength="64" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="字典编码" prop="dictTypeCode">
							<el-input v-model="ruleForm.dictTypeCode" placeholder="请输入字典编码" maxlength="64" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="列表是否缩进" prop="whetherRetract">
							<el-input v-model="ruleForm.whetherRetract" placeholder="请输入列表是否缩进" maxlength="8" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="是否必填" prop="whetherRequired">
							<el-input v-model="ruleForm.whetherRequired" placeholder="请输入是否必填" maxlength="8" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="是否可排序" prop="whetherSortable">
							<el-input v-model="ruleForm.whetherSortable" placeholder="请输入是否可排序" maxlength="8" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="是否是查询条件" prop="queryWhether">
							<el-input v-model="ruleForm.queryWhether" placeholder="请输入是否是查询条件" maxlength="8" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="查询方式" prop="queryType">
							<el-input v-model="ruleForm.queryType" placeholder="请输入查询方式" maxlength="16" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="列表显示" prop="whetherTable">
							<el-input v-model="ruleForm.whetherTable" placeholder="请输入列表显示" maxlength="8" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="增改" prop="whetherAddUpdate">
							<el-input v-model="ruleForm.whetherAddUpdate" placeholder="请输入增改" maxlength="8" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="主键" prop="columnKey">
							<el-input v-model="ruleForm.columnKey" placeholder="请输入主键" maxlength="8" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="数据库中类型" prop="dataType">
							<el-input v-model="ruleForm.dataType" placeholder="请输入数据库中类型" maxlength="64" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="是否通用字段" prop="whetherCommon">
							<el-input v-model="ruleForm.whetherCommon" placeholder="请输入是否通用字段" maxlength="8" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="显示文本字段" prop="displayColumn">
							<el-input v-model="ruleForm.displayColumn" placeholder="请输入显示文本字段" maxlength="0" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="选中值字段" prop="valueColumn">
							<el-input v-model="ruleForm.valueColumn" placeholder="请输入选中值字段" maxlength="128" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="父级字段" prop="pidColumn">
							<el-input v-model="ruleForm.pidColumn" placeholder="请输入父级字段" maxlength="128" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
					<el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12" class="mb20">
						<el-form-item label="排序" prop="orderNo">
							<el-input v-model="ruleForm.orderNo" placeholder="请输入排序" maxlength="0" show-word-limit clearable />
							
						</el-form-item>
						
					</el-col>
				</el-row>
			</el-form>
			<template #footer>
				<span class="dialog-footer">
					<el-button @click="cancel">取 消</el-button>
					<el-button type="primary" @click="submit">确 定</el-button>
				</span>
			</template>
		</el-dialog>
	</div>
</template>
<style scoped>
:deep(.el-select),
:deep(.el-input-number) {
	width: 100%;
}
</style>
<script lang="ts" setup>
	import { ref,onMounted } from "vue";
	import { getDictDataItem as di, getDictDataList as dl } from '/@/utils/dict-utils';
	import { ElMessage } from "element-plus";
	import type { FormRules } from "element-plus";
	import { addSysCodeGenConfig, updateSysCodeGenConfig, detailSysCodeGenConfig } from "/@/api/main/sysCodeGenConfig";

	//父级传递来的参数
	var props = defineProps({
		title: {
		type: String,
		default: "",
	},
	});
	//父级传递来的函数，用于回调
	const emit = defineEmits(["reloadTable"]);
	const ruleFormRef = ref();
	const isShowDialog = ref(false);
	const ruleForm = ref<any>({});
	//自行添加其他规则
	const rules = ref<FormRules>({
		codeGenId: [{required: true, message: '请输入主表Id！', trigger: 'blur',},],
		columnName: [{required: true, message: '请输入字段名称！', trigger: 'blur',},],
		propertyName: [{required: true, message: '请输入属性名称！', trigger: 'blur',},],
		columnLength: [{required: true, message: '请输入字段数据长度！', trigger: 'blur',},],
		orderNo: [{required: true, message: '请输入排序！', trigger: 'blur',},],
	});

	// 打开弹窗
	const openDialog = async (row: any) => {
		// ruleForm.value = JSON.parse(JSON.stringify(row));
		// 改用detail获取最新数据来编辑
		let rowData = JSON.parse(JSON.stringify(row));
		if (rowData.id)
			ruleForm.value = (await detailSysCodeGenConfig(rowData.id)).data.result;
		else
			ruleForm.value = rowData;
		isShowDialog.value = true;
	};

	// 关闭弹窗
	const closeDialog = () => {
		emit("reloadTable");
		isShowDialog.value = false;
	};

	// 取消
	const cancel = () => {
		isShowDialog.value = false;
	};

	// 提交
	const submit = async () => {
		ruleFormRef.value.validate(async (isValid: boolean, fields?: any) => {
			if (isValid) {
				let values = ruleForm.value;
				if (ruleForm.value.id == undefined || ruleForm.value.id == null || ruleForm.value.id == "" || ruleForm.value.id == 0) {
					await addSysCodeGenConfig(values);
				} else {
					await updateSysCodeGenConfig(values);
				}
				closeDialog();
			} else {
				ElMessage({
					message: `表单有${Object.keys(fields).length}处验证失败，请修改后再提交`,
					type: "error",
				});
			}
		});
	};







	// 页面加载时
	onMounted(async () => {
	});

	//将属性或者函数暴露给父组件
	defineExpose({ openDialog });
</script>




