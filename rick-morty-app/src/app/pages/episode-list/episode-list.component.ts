import { Component, inject, signal } from '@angular/core';
import { Episode, EpisodeResponse } from '../../interfaces/episode';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { EpisodeService } from '../../services/episode.service';

@Component({
  selector: 'app-episode-list',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule
  ],
  templateUrl: './episode-list.component.html',
  styleUrl: './episode-list.component.scss'
})
export class EpisodeListComponent {
  private http = inject(HttpClient);
  episodes = signal<EpisodeResponse | null>(null);

  currentPage = 1;
  itemsPerPage = 12;
  hasNextPage = true;

  constructor(private episodeService: EpisodeService) {
    this.fetchPage(this.currentPage);
  }

  fetchPage(page: number): void {
    this.episodeService.getEpisodesByPage(page)
      .subscribe(data => {
        this.episodes.set(data);
        this.currentPage = data.currentPage;
        this.hasNextPage = !!data.next;
      });
  }

  nextPage(): void {
    if (this.hasNextPage) {
      this.fetchPage(this.currentPage + 1);
    }
  }

  prevPage(): void {
    if (this.currentPage > 1) {
      this.fetchPage(this.currentPage - 1);
    }
  }
}
