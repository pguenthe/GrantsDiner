import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { MenuComponent } from './menu/menu.component';
import { MenuCategoryComponent } from './menu-category/menu-category.component';
import { CartComponent } from './cart/cart.component';
import { CartItemComponent } from './cart-item/cart-item.component';
import { MenuDataService } from './menu-data';
import { CartDataService } from './cart-data.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    MenuComponent,
    MenuCategoryComponent,
    CartComponent,
    CartItemComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: 'cart', component: CartComponent },
      { path: '', component: MenuComponent},
    ])
  ],
  providers: [MenuDataService, CartDataService],
  bootstrap: [AppComponent]
})
export class AppModule { }
