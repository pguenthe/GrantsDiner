/// <reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { MenuCategoryComponent } from './menu-category.component';

let component: MenuCategoryComponent;
let fixture: ComponentFixture<MenuCategoryComponent>;

describe('menu-category component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ MenuCategoryComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(MenuCategoryComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});