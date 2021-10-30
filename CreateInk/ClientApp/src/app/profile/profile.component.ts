import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Artist } from '../artist';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.GetArtist();
  }

  SERVER_URL = "https://localhost:44369/artist/id?id=2FD77EEB-3473-4FAA-B36A-08D99B30E14F";
  folderPath = '../../assets/Arts/';
  artsPath = [];
  artist: Artist;
  arts = [];
  profilePic = '../../assets/UserImage/';

  

  //http://localhost:4200/users?order=popular
  /** GET heroes from the server */

  GetArtist() {
    return this.http.get<Artist>(this.SERVER_URL).subscribe(res => {
      this.artist = res;
      res.arts.forEach(art => {
        this.arts.push(this.folderPath + art.id.toUpperCase())
      });
    });
    //let ok = this.artist.firstName;
  }  

  

}
