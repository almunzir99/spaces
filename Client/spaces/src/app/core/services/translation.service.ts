import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TranslationService {
  private _currentLang = new BehaviorSubject<string>("en");
  changeLang(lang: string) {
    this._currentLang.next(lang);
  }
  
  public get currentLang() : string {
    return this._currentLang.value;
  }
  
  constructor() { }
}
