import request from '/@/utils/request';
enum Api {
  AddSysCodeGenConfig = '/api/sysCodeGenConfig/add',
  DeleteSysCodeGenConfig = '/api/sysCodeGenConfig/delete',
  UpdateSysCodeGenConfig = '/api/sysCodeGenConfig/update',
  PageSysCodeGenConfig = '/api/sysCodeGenConfig/page',
  DetailSysCodeGenConfig = '/api/sysCodeGenConfig/detail',
}

// 增加代码生成字段配置表
export const addSysCodeGenConfig = (params?: any) =>
	request({
		url: Api.AddSysCodeGenConfig,
		method: 'post',
		data: params,
	});

// 删除代码生成字段配置表
export const deleteSysCodeGenConfig = (params?: any) => 
	request({
			url: Api.DeleteSysCodeGenConfig,
			method: 'post',
			data: params,
		});

// 编辑代码生成字段配置表
export const updateSysCodeGenConfig = (params?: any) => 
	request({
			url: Api.UpdateSysCodeGenConfig,
			method: 'post',
			data: params,
		});

// 分页查询代码生成字段配置表
export const pageSysCodeGenConfig = (params?: any) => 
	request({
			url: Api.PageSysCodeGenConfig,
			method: 'post',
			data: params,
		});

// 详情代码生成字段配置表
export const detailSysCodeGenConfig = (id: any) => 
	request({
			url: Api.DetailSysCodeGenConfig,
			method: 'get',
			data: { id },
		});


