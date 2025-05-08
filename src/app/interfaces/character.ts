export interface Character {
  id:       number;
  name:     string;
  status:   string;
  species:  string;
  type:     string;
  gender:   Gender;
  origin:   Location;
  location: Location;
  image:    string;
  episode:  string[];
  url:      string;
  created:  Date;
}

export enum Gender {
  Female = "Female",
  Genderless = "Genderless",
  Male = "Male",
}

export interface Location {
  name: string;
  url:  string;
}