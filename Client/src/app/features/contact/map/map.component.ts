import { AfterViewInit, Component, ElementRef, ViewChild } from '@angular/core';
import { GoogleMap, MapInfoWindow, MapMarker } from '@angular/google-maps';


@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.css']
})
export class MapComponent implements AfterViewInit {
  constructor() { }
  @ViewChild('marker', { static: false, }) marker: ElementRef<HTMLElement> | any;;

  @ViewChild(MapInfoWindow) infoWindow: MapInfoWindow | undefined;
  mapOptions: google.maps.MapOptions = {
    center: { lat: 43.86099666996757, lng: 25.978029847119984 },
    zoom: 15.1

  }

  ngAfterViewInit(): void {
    this.openInfoWindow(this.marker)
  }

  markerPositions = {
    positionOne: { lat: 43.86099666996757, lng: 25.978029847119984 }
  }

  markerOptions: google.maps.MarkerOptions = {
    draggable: false,
  };

  openInfoWindow(marker: MapMarker) {

    if (this.infoWindow != undefined) {
      this.infoWindow.open(marker);
      console.log('opened');
    }

  }


}
