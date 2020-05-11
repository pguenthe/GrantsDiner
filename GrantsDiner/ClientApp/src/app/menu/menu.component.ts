import { Component } from '@angular/core';
import { MenuDataService } from '../menu-data';
import { MenuItem } from '../interfaces/menu';
import { CartDataService } from '../cart-data.service';

@Component({
    selector: 'app-menu',
    templateUrl: './menu.component.html',
    styleUrls: ['./menu.component.scss']
})
/** menu component*/
export class MenuComponent {
  /** menu ctor */
  constructor(private menuData: MenuDataService,
    private cartData: CartDataService) { }

  items: MenuItem[];

  ngOnInit() {
    this.menuData.getMenuItems().subscribe(
      (data: MenuItem[]) => {
        this.items = data;
      },
      error => console.error(error)
    );
  }

  add(id: number) {
    this.cartData.postCartItem(id).subscribe(
      (data: any) => console.log('success! ' + id), //TODO: change the button
      error => console.error(error)
    )
  }
}
