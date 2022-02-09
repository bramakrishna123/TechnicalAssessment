import { Component, Input, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { AssetService } from "../../services/asset.service";
import { IAsset } from "../../types/asset.model";

@Component({
  selector: "asset-detail",
  templateUrl: "./asset-detail.component.html",
  styleUrls: ["./asset-detail.component.scss"]
})
export class AssetDetailComponent implements OnInit {
  asset?: IAsset;
  constructor(private _assetService: AssetService,
    private _route: ActivatedRoute,
    private _router: Router) { }

  ngOnInit(): void {
    const id = this._route.snapshot.paramMap.get('id');
    if (id) {
      this._assetService.getAssetDetailsById(id).subscribe((result: IAsset) => {
        this.asset = result;
      },
        (err) => console.log('Oops!!! Error occured while fetching data'));
    }
  }
  gotoList(): void {
    this._router.navigate(['/asset-list'])
  }
}
