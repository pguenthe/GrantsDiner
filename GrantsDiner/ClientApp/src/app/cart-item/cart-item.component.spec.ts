/// <reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { CartItemComponent } from './cart-item.component';

let component: CartItemComponent;
let fixture: ComponentFixture<CartItemComponent>;

describe('cart-item component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ CartItemComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(CartItemComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});