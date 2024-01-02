import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-paginator',
  templateUrl: './paginator.component.html',
  styleUrl: './paginator.component.css'
})
export class PaginatorComponent {
  @Input() currentPage?: number;
  @Input() totalPages?: number;

  @Output() pageChanged = new EventEmitter<number>();

  constructor() { }

  onPageChange(page: number): void {
    if (page >= 1 && page <= Number(this.totalPages)) {
      this.pageChanged.emit(page);
    }
  }

  getPages(): number[] {
    const pages = [];
    for (let i = 1; i <= Number(this.totalPages); i++) {
      pages.push(i);
    }
    return pages;
  }
}
