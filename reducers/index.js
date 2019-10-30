import { RECEIVE_DECKS, ADD_DECK, ADD_CARD, DELETE_DECK } from '../actions/types';

const initialState = {
	// React: {
	// 	title: 'React',
	// 	questions: [
	// 		{
	// 			question: 'What is React?',
	// 			answer: 'A library for managing user interfaces'
	// 		},
	// 		{
	// 			question: 'Where do you make Ajax requests in React?',
	// 			answer: 'The componentDidMount lifecycle event'
	// 		}
	// 	]
	// },
	// JavaScript: {
	// 	title: 'JavaScript',
	// 	questions: [
	// 		{
	// 			question: 'What is a closure?',
	// 			answer:
	// 				'The combination of a function and the lexical environment within which that function was declared.'
	// 		}
	// 	]
	// }
};

function decksReducer(state = initialState, action) {
	switch (action.type) {
		case RECEIVE_DECKS:
			return { ...action.decks };
			break;
		case ADD_DECK:
			return { ...state, [action.title]: { title: action.title, questions: [] } };
		case ADD_CARD:
			return {
				...state,
				[action.id]: {
					...state[action.id],
					questions: [ ...state[action.id].questions, action.card ]
				}
			};
		case DELETE_DECK:
			const newObject = { ...state };
			delete newObject[action.title];
			return newObject;
		default:
			return state;
	}
}

export default decksReducer;
