import { Component } from '@angular/core';
import { MenuDataService } from '../menu-data';
import { MenuItem } from '../interfaces/menu';

@Component({
    selector: 'app-menu',
    templateUrl: './menu.component.html',
    styleUrls: ['./menu.component.scss']
})
/** menu component*/
export class MenuComponent {
  /** menu ctor */
  constructor(private menuData: MenuDataService) { }

  items: MenuItem[];

  ngOnInit() {
    this.menuData.getMenuItems().subscribe(
      (data: MenuItem[]) => {
        this.items = data;
      },
      error => console.error(error)
    );
  }
}
