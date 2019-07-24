Feature('NavigateHomepage');

Scenario('Go to Leaderboard', (I) => {
    I.amOnPage('http://devforum.azurewebsites.net/');
    I.waitForText('Leaderboard');
    I.see('Leaderboard');
    I.clickLink('//html/body/section[1]/div/div/div/ul/li[2]/a');
    I.waitForText('This Weeks Stars');
    I.wait(3);
});

Scenario('Go to Activity', (I) => {
    I.amOnPage('http://devforum.azurewebsites.net/');
    I.waitForText('Activity');
    I.see('Activity');
    I.clickLink('//html/body/section[1]/div/div/div/ul/li[3]/a');
    I.waitForText('is a new member in the forum')
    I.wait(3);
})

Scenario('Go to Badges', (I) => {
    I.amOnPage('http://devforum.azurewebsites.net/');
    I.waitForText('Badges');
    I.see('Badges');
    I.clickLink('//html/body/section[1]/div/div/div/ul/li[4]/a');
    I.waitForText('Photogenic')
    I.wait(3);
})

Scenario('View posts tagged with QUICKREACH', (I) => {
    I.amOnPage('http://devforum.azurewebsites.net/');
    I.waitForText('QUICKREACH');
    I.see('QUICKREACH');
    I.clickLink('//*[@id="main"]/div/div[2]/div/div[3]/ul/li[1]/span/a');
    I.waitForText('Discussions Tagged With:quickreach')
    I.wait(3);
})

Scenario('Search posts with query "test"', (I) => {
    I.amOnPage('http://devforum.azurewebsites.net/');
    I.waitForElement('//*[@id="term"]');
    I.fillField('//*[@id="term"]', 'test');
    I.pressKey('Enter');
    I.wait(3);
})
