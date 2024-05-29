/* tslint:disable */
/* eslint-disable */
/**
 * Admin.NET 通用权限开发平台
 * 让 .NET 开发更简单、更通用、更流行。前后端分离架构(.NET6/Vue3)，开箱即用紧随前沿技术。<br/><a href='https://gitee.com/zuohuaijun/Admin.NET/'>https://gitee.com/zuohuaijun/Admin.NET</a>
 *
 * OpenAPI spec version: 1.0.0
 * 
 *
 * NOTE: This class is auto generated by the swagger code generator program.
 * https://github.com/swagger-api/swagger-codegen.git
 * Do not edit the class manually.
 */

import { NoticeStatusEnum } from './notice-status-enum';
import { NoticeTypeEnum } from './notice-type-enum';
 /**
 * 
 *
 * @export
 * @interface AddNoticeInput
 */
export interface AddNoticeInput {

    /**
     * 雪花Id
     *
     * @type {number}
     * @memberof AddNoticeInput
     */
    id?: number;

    /**
     * 创建时间
     *
     * @type {Date}
     * @memberof AddNoticeInput
     */
    createTime?: Date | null;

    /**
     * 更新时间
     *
     * @type {Date}
     * @memberof AddNoticeInput
     */
    updateTime?: Date | null;

    /**
     * 创建者Id
     *
     * @type {number}
     * @memberof AddNoticeInput
     */
    createUserId?: number | null;

    /**
     * 创建者姓名
     *
     * @type {string}
     * @memberof AddNoticeInput
     */
    createUserName?: string | null;

    /**
     * 修改者Id
     *
     * @type {number}
     * @memberof AddNoticeInput
     */
    updateUserId?: number | null;

    /**
     * 修改者姓名
     *
     * @type {string}
     * @memberof AddNoticeInput
     */
    updateUserName?: string | null;

    /**
     * 软删除
     *
     * @type {boolean}
     * @memberof AddNoticeInput
     */
    isDelete?: boolean;

    /**
     * 标题
     *
     * @type {string}
     * @memberof AddNoticeInput
     */
    title: string;

    /**
     * 内容
     *
     * @type {string}
     * @memberof AddNoticeInput
     */
    content: string;

    /**
     * @type {NoticeTypeEnum}
     * @memberof AddNoticeInput
     */
    type?: NoticeTypeEnum;

    /**
     * 发布人Id
     *
     * @type {number}
     * @memberof AddNoticeInput
     */
    publicUserId?: number;

    /**
     * 发布人姓名
     *
     * @type {string}
     * @memberof AddNoticeInput
     */
    publicUserName?: string | null;

    /**
     * 发布机构Id
     *
     * @type {number}
     * @memberof AddNoticeInput
     */
    publicOrgId?: number;

    /**
     * 发布机构名称
     *
     * @type {string}
     * @memberof AddNoticeInput
     */
    publicOrgName?: string | null;

    /**
     * 发布时间
     *
     * @type {Date}
     * @memberof AddNoticeInput
     */
    publicTime?: Date | null;

    /**
     * 撤回时间
     *
     * @type {Date}
     * @memberof AddNoticeInput
     */
    cancelTime?: Date | null;

    /**
     * @type {NoticeStatusEnum}
     * @memberof AddNoticeInput
     */
    status?: NoticeStatusEnum;
}
