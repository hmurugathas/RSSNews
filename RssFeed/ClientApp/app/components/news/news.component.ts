import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'news',
    templateUrl: './news.component.html'
})
export class NewsComponent {
    public newsItems: NewsItems[];

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get(baseUrl + 'api/News/BBC').subscribe(result => {
            this.newsItems = result.json() as NewsItems[];
        }, error => console.error(error));
    }
}

interface NewsItems {
    title: string;
    description: string;
    link: string;
    image: {
        width: number,
        height: number,
        url: string
    };
}
