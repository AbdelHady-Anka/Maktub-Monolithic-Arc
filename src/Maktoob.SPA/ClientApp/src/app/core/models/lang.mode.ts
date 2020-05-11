export class Lang {
    key?: string;
    val?: string;
    name?: string;
    dir?: string;
}

export interface LangModel{
    AvailableLangs: Lang[];
    ActiveLang: Lang;
}