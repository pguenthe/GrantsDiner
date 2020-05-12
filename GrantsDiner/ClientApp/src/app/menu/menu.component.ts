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

  categories: string[];
  menuSection: boolean[] = [];

  ngOnInit() {
    this.menuData.getCategories().subscribe(
      (data: string[]) => {
        for (let i = 0; i < data.length; i++) {
          this.menuSection.push(true);
        }
        this.categories = data;
      },
      error => console.error(error)
    );
  }

  showMenuSection(section: number) {
    for (let i = 0; i < this.menuSection.length; i++) {
      this.menuSection[i] = true;
    }

    this.menuSection[section] = false;
  }

}
