import { AsyncPipe, CommonModule, NgFor, NgIf } from '@angular/common';
import { Component, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EpisodeService } from '../../services/episode.service';
import { switchMap } from 'rxjs';

@Component({
  selector: 'app-episode-detail',
  standalone: true,
  imports: [CommonModule, AsyncPipe, NgIf, NgFor],
  templateUrl: './episode-detail.component.html',
  styleUrls: ['./episode-detail.component.scss']
})
export class EpisodeDetailComponent {
  private route = inject(ActivatedRoute);
  private service = inject(EpisodeService);

  episode$ = this.route.paramMap
    .pipe(switchMap(params => this.service.getEpisodeById(+params.get('id')!)));
}