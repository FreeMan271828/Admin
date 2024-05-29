import request from '/@/utils/request';
enum Api {
  AddSysFile = '/api/sysFile/add',
  DeleteSysFile = '/api/sysFile/delete',
  UpdateSysFile = '/api/sysFile/update',
  PageSysFile = '/api/sysFile/page',
  DetailSysFile = '/api/sysFile/detail',
}

// 增加李兴文
export const addSysFile = (params?: any) =>
	request({
		url: Api.AddSysFile,
		method: 'post',
		data: params,
	});

// 删除李兴文
export const deleteSysFile = (params?: any) => 
	request({
			url: Api.DeleteSysFile,
			method: 'post',
			data: params,
		});

// 编辑李兴文
export const updateSysFile = (params?: any) => 
	request({
			url: Api.UpdateSysFile,
			method: 'post',
			data: params,
		});

// 分页查询李兴文
export const pageSysFile = (params?: any) => 
	request({
			url: Api.PageSysFile,
			method: 'post',
			data: params,
		});

// 详情李兴文
export const detailSysFile = (id: any) => 
	request({
			url: Api.DetailSysFile,
			method: 'get',
			data: { id },
		});


