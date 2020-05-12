import { Component } from '@angular/core';
import { MenuDataService } from '../menu-data';
import { CartDataService } from '../cart-data.service';
import { CartItem, JoinedItem } from '../interfaces/cart';

@Component({
    selector: 'app-cart',
    templateUrl: './cart.component.html',
    styleUrls: ['./cart.component.scss']
})
/** cart component*/
export class CartComponent {
    /** cart ctor */
  constructor(private menuData: MenuDataService,
    private cartData: CartDataService) { }

  cartItems: JoinedItem[];
  total: number;

  ngOnInit() {
    this.get();
  }

  delete(id: number) {
    this.cartData.deleteCartItem(id).subscribe(
      (data: any) => {
        console.log(data);
        this.get();
      },
      error => console.error(error)
    );
  }

  update(item:CartItem) {
    this.cartData.updateCartItem(item).subscribe(
      (data: any) => {
        console.log(data);
        this.get();
      },
      error => console.error(error)
    );
  }

  get() {
    this.cartData.getCartItems().subscribe(
      (data: JoinedItem[]) => {
        this.cartItems = data;
        this.getTotal();
      },
      error => console.error(error)
    );
  }

  getTotal() {
    this.total = 0;
    for (let item of this.cartItems) {
      this.total += item.quantity * item.price;
    }
  }
}
