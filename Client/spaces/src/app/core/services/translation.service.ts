import { Injectable } from '@angular/core';
import { BehaviorSubject, Observer, Subscription } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TranslationService {
  private _currentLang = new BehaviorSubject<string>("en");
  changeLang(lang: string) {
    this._currentLang.next(lang);
    this._currentLang.subscribe()
  }
  subscribe(observer?: Partial<Observer<string>> | undefined) : Subscription {
      return this._currentLang.subscribe(observer);
  }
  
  public get currentLang() : string {
    return this._currentLang.value;
  }
  
  constructor() { }
}
