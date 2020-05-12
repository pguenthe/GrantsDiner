import { Component, Input, EventEmitter, Output } from '@angular/core';
import { JoinedItem, CartItem } from '../interfaces/cart';

@Component({
    selector: 'app-cart-item',
    templateUrl: './cart-item.component.html',
    styleUrls: ['./cart-item.component.scss']
})
/** cart-item component*/
export class CartItemComponent {
  @Input() item: JoinedItem;
  @Output() deleteEmitter = new EventEmitter<number>();
  @Output() updateEmitter = new EventEmitter<CartItem>();

    /** cart-item ctor */
    constructor() {

  }

  delete(id: number) {
    this.deleteEmitter.emit(id);
  }

  update(id: number, quantity: number) {
    console.log("updating...");

    let cartItem: CartItem = {
      id: this.item.id,
      userID: this.item.userID,
      itemID: this.item.itemID,
      quantity: +quantity
    }

    this.updateEmitter.emit(cartItem);
  }
}
