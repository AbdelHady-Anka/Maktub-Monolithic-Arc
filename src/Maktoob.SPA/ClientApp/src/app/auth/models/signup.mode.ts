import { GError } from 'src/app/core/results/error';

export interface SignUpModel {
    EmailErrors?: GError[];
    UsernameErrors?: GError[]
    PasswordErrors?: GError[]
}