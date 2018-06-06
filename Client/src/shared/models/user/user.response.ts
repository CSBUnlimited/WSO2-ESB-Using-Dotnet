import { UserVM } from './user.vm';
import { BaseResponse } from './../base.response';

export interface UserResponse extends BaseResponse {
    users?: UserVM[];
}