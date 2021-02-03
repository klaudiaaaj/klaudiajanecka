import React, {useState, useEffect} from 'react';
import ArticlesComponent from "./MyArticlesComponent";
import {postArticle} from "../../api/articles";
import ArticlesDialog from "./addArticle/ArticlesDialog";
import { CategoryModel, PostArticleDto} from "../../api/Models/dto/dto";
import {getCategory} from '../../api/categories';
import {postArticleFile} from '../../api/articles';

const ArticlesContainer = () => {
    const [isOpen, setIsOpen] = useState(false);
    const [category, setCategory] = useState<CategoryModel[]>([]);

    useEffect(() => {
        async function fetchData() {
            const stat = await getCategory();
            setCategory(stat);
        }
        fetchData();
    }, []);


    const addArticle = async (formData: PostArticleDto, file: File) => {
        const response = await postArticle(formData);
        await postArticleFile(file, response.id);
    }

    const handleAddArticleClick = () => {
        setIsOpen(true);
    }

    const handleClose = () => {
        setIsOpen(false);
    }

    return (
        <>
            <ArticlesComponent
                onAddArticleDialogShow={handleAddArticleClick}
            />
            <ArticlesDialog
                open={isOpen}
                handleClose={handleClose}
                addArticle={addArticle}
                categoryList={category}
            />
        </>
    );

};

export default ArticlesContainer;