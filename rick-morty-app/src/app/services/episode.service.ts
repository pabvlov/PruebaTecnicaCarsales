import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Episode, EpisodeResponse } from '../interfaces/episode';
import { HttpClient } from '@angular/common/http';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EpisodeService {

  constructor(private http: HttpClient) { }

  getEpisodeById(id: number): Observable<Episode> {
    return this.http.get<Episode>(`${environment.api}/episode/${id}`);
  }

  getEpisodesByPage(page: number): Observable<EpisodeResponse> {
    return this.http.get<EpisodeResponse>(`${environment.api}/episode?page=${page}`);
  }
  
}
