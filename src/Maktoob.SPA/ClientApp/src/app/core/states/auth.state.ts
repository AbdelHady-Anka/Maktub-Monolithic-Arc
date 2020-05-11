import { TokenModel } from '../models/token.model';

export interface TokenState {
    TokenModel: TokenModel;
    Claims: { [index: string]: any }
}