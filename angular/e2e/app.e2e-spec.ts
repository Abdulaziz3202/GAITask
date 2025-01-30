import { GAITaskTemplatePage } from './app.po';

describe('GAITask App', function() {
  let page: GAITaskTemplatePage;

  beforeEach(() => {
    page = new GAITaskTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
