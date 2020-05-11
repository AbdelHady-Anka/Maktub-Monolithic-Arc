import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';

import { IStorageService } from '../core/services/storage.service';
import { LangModel } from '../core/models/lang.mode';
import { ILangFacade } from '../core/facades/lang.facade';

@Component({
  selector: 'app-root',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.scss']
})
export class AuthComponent implements OnInit {
  vm$: Observable<LangModel> = this.langService.ViewModel$;

  constructor(public langService: ILangFacade) { }
  ngOnInit(): void { }
}
