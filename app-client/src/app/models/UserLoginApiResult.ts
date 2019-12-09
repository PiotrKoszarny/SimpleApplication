export interface UserLoginApiResult{
    userId: string;
    email: string;
    isSuccessed: boolean;
    isLocked: boolean;
    loginError: string;
    token: string;
}