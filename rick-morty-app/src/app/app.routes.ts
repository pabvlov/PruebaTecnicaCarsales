import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    loadComponent: () => import('./layouts/main-layout/main-layout.component').then(m => m.MainLayoutComponent),
    children: [
      {
        path: '',
        loadComponent: () => import('./pages/episode-list/episode-list.component').then(m => m.EpisodeListComponent),
      },
      {
        path: 'episode/:id',
        loadComponent: () => import('./pages/episode-detail/episode-detail.component').then(m => m.EpisodeDetailComponent),
      },
    ]
  },
  { path: '**', redirectTo: '' }
];