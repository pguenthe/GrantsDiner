import { Component, Input } from '@angular/core';
import { MenuDataService } from '../menu-data';
import { MenuItem } from '../interfaces/menu';
import { CartDataService } from '../cart-data.service';

@Component({
    selector: 'app-menu-category',
    templateUrl: './menu-category.component.html',
    styleUrls: ['./menu-category.component.scss']
})
/** menu-category component*/
export class MenuCategoryComponent {
  @Input() category: string;
  items: MenuItem[];

  constructor(private menuData: MenuDataService,
    private cartData: CartDataService) { }

  ngOnInit() {
    this.menuData.getMenuItemsByCategory(this.category).subscribe(
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
