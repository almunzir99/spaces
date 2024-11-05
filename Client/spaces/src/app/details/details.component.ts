import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { ToastrService } from 'ngx-toastr';
import { forkJoin, map, Subscription } from 'rxjs';
import { Article } from '../core/models/article.model';
import { Comment } from '../core/models/comment.model';
import { DetailService } from '../core/services/detail.service';
import { TranslationService } from '../core/services/translation.service';
import { HTMLToText } from '../shared/utils/html-to-text';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.scss']
})
export class DetailsComponent implements OnInit {
  subscription = new Subscription();
  item?: Article;
  items: Article[] = [];
  comments: Comment[] = [];
  pageLoading = false;
  isButtonLoading = false;
  currentLang: string = "en";
  HTMLToText = HTMLToText;
  base: string = "articles";
  articleId?: number;
  constructor(private _service: DetailService, private sanitizer: DomSanitizer, private _translationService: TranslationService, private route: ActivatedRoute, private toastr: ToastrService) {
  }
  loadData(base: string, id: number) {
    this.pageLoading = true;
    var obs = forkJoin([
      this._service.single(base, id),
      this._service.get(base),
      this._service.getComments(base, id),
    ]).pipe(map(([item, items, comments]) => {
      return { item, items, comments }
    }));
    var sub = obs.subscribe({
      next: (res) => {
        this.pageLoading = false;
        this.item = res.item.data!;
        this.items = res.items.data!;
        this.comments = res.comments.data!;
        if(this.item.content)
        {
          this.item.safeArContent = this.sanitizer.bypassSecurityTrustHtml(this.item.content!.ar!);
          this.item.safeEnContent = this.sanitizer.bypassSecurityTrustHtml(this.item.content!.en!);

        }
      },
      error: (err) => {
        this.pageLoading = false;
        console.log(err);
      }
    })
    this.subscription.add(sub);
  }
  ngOnInit(): void {
    this.route.params.subscribe(res => {
      this.currentLang = this._translationService.currentLang;
      this.base = res['base'];
      this.articleId = res['id'];
      this.loadData(this.base, res['id']);
      this._translationService.subscribe({
        next: (res) => {
          this.currentLang = res;
        }
      })
    })
  }
  postComment(name: string, email: string, content: string) {
    if (this.isButtonLoading)
      return;
    this.isButtonLoading = true;
    var comment: Comment = {
      name: name,
      email: email,
      content: content
    }
    this._service.postComment(this.base, this.articleId!, comment).subscribe({
      next: (res) => {
        this.isButtonLoading = false;
        if (this._translationService.currentLang == 'ar')
          this.toastr.success('نجاح', 'تم نشر التعليق بنجاح');
        else
          this.toastr.success('Success', 'Comment Submitted Successfully!');
        this.comments.push(res.data!);

      }, error: (err) => {

        this.isButtonLoading = false;
        console.log(err);
        if (this._translationService.currentLang == 'ar')
          this.toastr.error('فشل', 'فشل نشر التعليق الرجاء اعادة المحاولة');
        else
          this.toastr.error('Error', 'Failed To submit comment, please try again!');
      }
    })
  }
  getDate(datetime: string): string {
    var date = new Date(datetime);
    return date.toDateString();

  }
  ngOnDestroy() {
    this.subscription.unsubscribe();
  }


}
