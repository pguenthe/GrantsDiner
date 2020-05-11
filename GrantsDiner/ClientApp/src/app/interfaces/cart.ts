export interface CartItem {
  id: number;
  itemID: number;
  userID: number;
  quantity: number;
}

export interface JoinedItem {
  id: number;
  itemID: number;
  userID: number;
  quantity: number;
  name: string;
  category: string;
  description: string;
  price: number;
}
