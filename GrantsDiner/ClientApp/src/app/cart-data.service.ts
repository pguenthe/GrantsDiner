import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CartItem, JoinedItem } from './interfaces/cart';

@Injectable()
export class CartDataService {
  userID: number;

  constructor(private http: HttpClient) {
    //user ID is a random number between 1 and 1,000,000
    this.userID = Math.floor(Math.random() * 1000000) + 1;
    //this.userID = 13;
  }

  getCartItems() {
    return this.http.get<JoinedItem[]>('/api/cart/' + this.userID);
  }

  deleteCartItem(itemID: number) {
    console.log("deleting...");
    return this.http.delete('/api/cart/' + itemID);
  }

  updateCartItem(item: CartItem) {
    if (item.quantity == 0) {
      return this.deleteCartItem(item.id);
    } else {
      console.log(`Received item to update: ${item.id} ${item.userID} ${item.itemID} ${item.quantity}`);
      return this.http.put('/api/cart/', item);
    }
  }

  postCartItem(itemID: number) {
    let item: CartItem = {
      id: 0,
      userID: this.userID,
      itemID: itemID,
      quantity: 1
    };

    return this.http.post<CartItem>('/api/cart', item);
  }
}
