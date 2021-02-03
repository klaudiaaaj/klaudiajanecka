import React from 'react';
import Grid from "@material-ui/core/Grid"
import {Button} from "@material-ui/core";
import Articles from "./MyArticles";

type Props = {
  onAddArticleDialogShow: () => void,
}

const ArticlesComponent: React.FC<Props> = (props) => (

  <Grid container spacing={1}>
    <Grid item xs={11}>
      <h1>My Articles</h1>
      <Articles/>
      <Grid item xs={10}>
        <Button
          variant="contained"
          color="primary"
          href="#contained-buttons"
          onClick={props.onAddArticleDialogShow}
        >
          Add Article
        </Button>
      </Grid>
    </Grid>
  </Grid>

);

export default ArticlesComponent;