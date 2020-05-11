import { Component, OnInit } from '@angular/core';
import { ILangFacade } from './core/facades/lang.facade';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  vm$ = this.langFacade.ViewModel$;
  /**
   * translate service injected here just to ensure its running in other parts of the app
   */

  constructor(private langFacade: ILangFacade) { }

  ngOnInit(): void { }
  title = 'Maktoob';
}
