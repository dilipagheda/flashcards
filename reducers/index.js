import { RECEIVE_DECKS, ADD_DECK, ADD_CARD, DELETE_DECK } from '../actions/types';

const initialState = {
	React: {
		title: 'React',
		questions: [
			{
				question: 'What is React?',
				answer: 'A library for managing user interfaces'
			},
			{
				question: 'Where do you make Ajax requests in React?',
				answer: 'The componentDidMount lifecycle event'
			}
		]
	},
	JavaScript: {
		title: 'JavaScript',
		questions: [
			{
				question: 'What is a closure?',
				answer:
					'The combination of a function and the lexical environment within which that function was declared.'
			}
		]
	}
};

function decks(state = initialState, action) {
	switch (action.type) {
		case RECEIVE_DECKS:
			return state;
			break;
		case ADD_DECK:
			return state;
		case ADD_CARD:
			return state;
		case DELETE_DECK:
			return state;
	}
}

export default decks;
