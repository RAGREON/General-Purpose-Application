import { Component, Input } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-side-bar-card',
  imports: [MatIconModule],
  templateUrl: './side-bar-card.html',
  styleUrl: './side-bar-card.scss',
})
export class SideBarCard {
  @Input() cardLabel: string = "";
  @Input() cardIcon: string = "";
  @Input() hideLabel: boolean = false;
}
