import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { IAsset } from "../types/asset.model";

@Injectable({
  providedIn: "root"
})
export class AssetService {
  constructor(private _httpClient: HttpClient) { }

  private getHeaders(): any {
    const headers: HttpHeaders = new HttpHeaders();
    headers.set("content-type", "application/json");
    return { headers };
  }

  getAssetServiceList(): Observable<IAsset[]> {
    const headers = this.getHeaders();
    return this._httpClient.get<IAsset[]>("/api/asset/asset-list", { headers });
  }

  getAssetDetailsById(Id: string): Observable<IAsset> {
    const headers = this.getHeaders();
    return this._httpClient.get<IAsset>(`/api/asset/asset-details/${Id}`, { headers });
  }
}
