import { GError } from 'src/app/core/results/error';

export interface SignInModel {
    CredentialsErrors?: GError[];
    PasswordErrors?: GError[];
}