import { Component, Injector } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  constructor(injector: Injector) {
  }
  title = 'app';
}
