export interface SignUpUserCommand {
    UserName: string;
    Email: string;
    Password: string;
}


export interface SignInUserCommand {
    Credentials: string;
    Password: string;
    EmailCredentials: boolean;
    RememberMe?: boolean;
    OperatingSystem?: string | undefined;
    Browser?: string | undefined;
    Device?: string | undefined;
    UserAgent?: string | undefined;
    OperatingSystemVersion?: string | undefined;
}


export interface SignOutUserCommand {
    UserId?: string;
    JwtId?: string | undefined;
    RefreshToken?: string | undefined;
    LogOutAll?: boolean;
}

export interface RefreshTokenCommand {
    AccessToken: string;
    RefreshToken: string;
}