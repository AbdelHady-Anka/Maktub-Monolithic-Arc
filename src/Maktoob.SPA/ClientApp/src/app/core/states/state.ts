import { GError } from '../results/error';

export class GState<T = void> {
    valid: boolean;
    data?: T;
    errors: GError[];
}