import { Character } from "./character";

export interface Episode {
  id:          number;
  name:        string;
  airDate:     string;
  episodeCode: string;
  characters:  Character[];
  url:         string;
  created:     Date;
}

export interface EpisodeResponse {
  results: Episode[];
  currentPage: number;
  next?: string;
  prev?: string;
}