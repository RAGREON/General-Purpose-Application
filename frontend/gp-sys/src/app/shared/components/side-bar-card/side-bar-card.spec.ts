import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SideBarCard } from './side-bar-card';

describe('SideBarCard', () => {
  let component: SideBarCard;
  let fixture: ComponentFixture<SideBarCard>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SideBarCard],
    }).compileComponents();

    fixture = TestBed.createComponent(SideBarCard);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
